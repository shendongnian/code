    class Program
    {
        static void Main(string[] args)
        {
            // Data
            var orders = new List<Order>
            {
                new Order(8, "Created"),
                new Order(3, "Delayed"),
                new Order(4, "Enroute"),
                new Order(2, "Created"),
                new Order(1, "Delayed"),
            };
    
            // Query
            var query = orders
                .GroupBy(x => x.Status)
                .Select(x => new {Status = x.Key, Total = x.Count()});
    
            // Display
            foreach (var item in query)
            {
                Console.WriteLine(item.Status + ": " + item.Total);
            }
            Console.ReadLine();
        }
    }
