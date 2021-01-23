    static void Main(string[] args) {
        var customers = new List<Customer> { 
            new Customer { Age = 23 }, 
            new Customer { Age = 23 }, 
            new Customer { Age = 23 }, 
            new Customer { Age = 24 }, 
            new Customer { Age = 25 } 
            };
        var mostCommonAge = customers
            .GroupBy(c => c.Age,
                (key, g) => new {Age = key, Count = g.Count()})
            .OrderByDescending(g => g.Count)
            .First();
                
        Console.WriteLine(mostCommonAge);
    }
