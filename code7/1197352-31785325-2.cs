    class Program
    {
        static void Main(string[] args)
        {
            AnimalCollection animals = AnimalSettings.Settings.AnimalList;
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.Name}\t\t{animal.Age}\t\t{animal.Type}");
            }
            Console.WriteLine();
            ZooCollection zoos = ZooSettings.Settings.ZooList;
            foreach (Zoo zoo in zoos)
            {
                Console.WriteLine(zoo.Name);
                foreach (Animal animal in zoo.Animals)
                {
                    Console.WriteLine($"{animal.Name}\t\t{animal.Age}\t\t{animal.Type}" );
                }
                Console.WriteLine();
            }
        }
    }
