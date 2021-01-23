    class Program
    {
        static void Main(string[] args)
        {
            List<string> nameCities = new List<string> { "Murcia", "Alicante", "Valencia", "Granada", "Albacete" };
            Cities(nameCities);
            Console.WriteLine("All out of cities. Press any key to exit.");
            Console.ReadKey();
        }
        static void Cities(List<string> cities)
        {
            while (cities.Count > 0)
                ChooseCity(cities);
        }
        private static void ChooseCity(List<string> cities)
        {
            Console.WriteLine("Which city would you like to choose?\n");
            for(int i = 0; i < cities.Count; i++)
                Console.WriteLine("{0} - {1}", i, cities[i]);
            string s = Console.ReadLine();
            int idx;
            if (int.TryParse(s, out idx) && idx >= 0 && idx < cities.Count)
            {
                Console.WriteLine("\nYou have chosen {0}\n", cities[idx]);
                cities.RemoveAt(idx);
            }
            else
            {
                Console.WriteLine("\nInvalid option");
            }
        }
    }
