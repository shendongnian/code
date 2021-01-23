    public class Program
    {
        // Animal
        public struct Animal
        {
            public string Name;
            public string Color;
            public int Weight;
            public int Age;
        }
        // Main
        public static void Main(string[] args)
        {
            Animal[] animals = new Animal[5];
            animals[0] = new Animal { Name = "Cat", Color = "Grey", Weight = 20, Age = 7  };
            animals[1] = new Animal { Name = "Dog", Color = "Grey", Weight = 20, Age = 7 };
            animals[2] = new Animal { Name = "Horse", Color = "Grey", Weight = 20, Age = 7 };
            animals[3] = new Animal { Name = "Rabbit", Color = "Grey", Weight = 20, Age = 7 };
            animals[4] = new Animal { Name = "Mouse", Color = "Grey", Weight = 20, Age = 7 };
            OutputAnimals(animals);
        }
        // Print out animals
        public static void OutputAnimals(Animal[] A)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Name: " + A[i].Name);
                Console.WriteLine("Weight: " + A[i].Weight);
                Console.WriteLine("Age: " + A[i].Age);
                Console.WriteLine("Color: " + A[i].Color);
            }
        }
    }
