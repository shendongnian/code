    class Program
    {
        static void Main(string[] args)
        {
            // Data
            var fruits = new List<Fruit>
            {
                new Fruit(23, 2),
                new Fruit(215, 2),
                new Fruit(256, 1),
                new Fruit(643, 3)
            };
    
            // Query
            var query = fruits
                .GroupBy(x => x.FruitType)
                .Select(x => new {Name = x.Key, Total = x.Count()});
    
            // Output
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + ": " + item.Total);
            }
            Console.ReadLine();
        }
    }
