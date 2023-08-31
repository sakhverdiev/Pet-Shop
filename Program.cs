using System;
using System.Collections.Generic;

namespace PetShopApp
{
    class Pet
    {
        public string? NickName { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public int Energy { get; set; }
        public int Price { get; set; }
        public int MealQuantity { get; set; }

        public virtual void Eat(int mealQuantity)
        {
            if (Energy == 100 || Energy > 100)
            {
                Console.WriteLine($"\n{NickName}: is full!!!");
                Energy = 100;
            }
            else
            {
                Energy += 10 * mealQuantity;
                MealQuantity += mealQuantity;
                Console.WriteLine($"\n{NickName}: has eaten {MealQuantity} meals");

                if (Energy > 100)
                {
                    Energy = 100;
                    Console.WriteLine($"\n{NickName}: is full");
                }
                Console.WriteLine($"\nEnergy:{Energy}%");
            }
        }

        public virtual void Sleep()
        {
            if (Energy == 100 || Energy > 100)
            {
                Console.WriteLine($"\n{NickName}: hasn't want to sleep!!!");
                Energy = 100;
            }
            else if (Energy == 0 || Energy < 50)
            {
                Console.WriteLine($"\n{NickName}: has slept!");
                Energy += 20;
                Console.WriteLine($"\nEnergy:{Energy}%");
            }
        }

        public virtual void Play()
        {
            if (Energy > 0)
            {
                Energy -= 10; // Enerji her Play vaxti 10% azalir
                Console.WriteLine($"\n{NickName}: has played");
                Console.WriteLine($"\nEnergy:{Energy}%");
            }

            if (Energy <= 25 && Energy > 0) // Enerji 25%-e dusende yuxulu olur
            {
                Console.WriteLine($"\n{NickName}: is sleepy");
            }
            else if (Energy == 0)
            {
                Console.WriteLine($"\n{NickName}: is tired, let's go to sleep!");
                Sleep();
            }
        }
    }

    class Cat : Pet
    {
        public Cat(string nickname, int age, string gender, int price)
        {
            NickName = nickname;
            Age = age;
            Gender = gender;
            Energy = 50;
            Price = price;
            MealQuantity = 0;
        }

        public override void Eat(int mealQuantity)
        {
            base.Eat(mealQuantity);
            Console.WriteLine($"Miyau... {NickName}");
        }
    }

    class Dog : Pet
    {
        public Dog(string nickname, int age, string gender, int price)
        {
            NickName = nickname;
            Age = age;
            Gender = gender;
            Energy = 50;
            Price = price;
            MealQuantity = 0;
        }

        public override void Eat(int mealQuantity)
        {
            base.Eat(mealQuantity);
            Console.WriteLine($"Havv Havv! {NickName}");
        }
    }

    class Bird : Pet
    {
        public Bird(string nickname, int age, string gender, int price)
        {
            NickName = nickname;
            Age = age;
            Gender = gender;
            Energy = 40;
            Price = price;
            MealQuantity = 0;
        }

        public override void Eat(int mealQuantity)
        {
            base.Eat(mealQuantity);
            Console.WriteLine($"Chip chip! {NickName}");
        }
    }

    class Fish : Pet
    {
        public Fish(string nickname, int age, string gender, int price)
        {
            NickName = nickname;
            Age = age;
            Gender = gender;
            Energy = 20;
            Price = price;
            MealQuantity = 0;
        }

        public override void Eat(int mealQuantity)
        {
            base.Eat(mealQuantity);
            Console.WriteLine($"Blup Blup{NickName}");
        }
    }

    class PetShop
    {
        public List<Pet> Pets { get; set; }

        public PetShop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t------------------------------");
            Console.WriteLine("\t\t\t\t\t| Welcome To The PetShop App |");
            Console.WriteLine("\t\t\t\t\t------------------------------");
            

            Console.ForegroundColor = ConsoleColor.Magenta;

            Pets = new List<Pet>();
        }

        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        public void RemoveByNickName(string nickname)
        {
            Pet foundPet = Pets.Find(pet => pet.NickName == nickname);
            if (foundPet != null)
            {
                Pets.Remove(foundPet);
                Console.WriteLine($"\n{nickname}: has been removed from ---> PetShop <---");
            }
            else
            {
                Console.WriteLine($"\nNo animal with {nickname} was found in PetShop");
            }
        }

        public int TotalQuantityMeal()
        {
            int totalMealQuantity = 0;
            foreach (var pet in Pets)
            {
                totalMealQuantity += pet.MealQuantity;
            }
            return totalMealQuantity;
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var pet in Pets)
            {
                totalPrice += pet.Price;
            }
            return totalPrice;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PetShop petShop = new PetShop();
            Cat cat = new Cat("Tom", 2, "Male", 10);
            petShop.AddPet(cat);

            Dog dog = new Dog("Rex", 2, "Male", 10);
            petShop.AddPet(dog);

            Bird bird = new Bird("Shaco", 2, "Male", 10);
            petShop.AddPet(bird);

            Fish fish = new Fish("Nemo", 2, "Male", 10);
            petShop.AddPet(fish);

            cat.Eat(1);
            dog.Eat(4);
            bird.Eat(2);
            fish.Eat(1);

            Console.WriteLine("\n------------------------");

            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
            cat.Play();
     

            petShop.RemoveByNickName("Tom");

            Console.WriteLine("\n\n\nTotal Price: " + petShop.TotalPrice());
            Console.WriteLine("\n\n\nTotal Quantity Meal: " + petShop.TotalQuantityMeal());
            Console.ReadLine();
        }
    }
}