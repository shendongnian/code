    class Program
    {
        public static void Main()
        {
            Measure(ForEachWithVariable);
            Measure(ForEachWithoutVariable);
            Console.ReadKey();
        }
        static void Measure(Action<List<Person>, List<Person>> action)
        {
            var clients = new[]
            {
                new Person { Age = 10 },
                new Person { Age = 20 },
                new Person { Age = 30 },
            }.ToList();
            var adultClients = new List<Person>();
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 1E6; i++)
                action(clients, adultClients);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());
            Console.WriteLine($"{adultClients.Count} adult clients found");
        }
        static void ForEachWithVariable(List<Person> clients, List<Person> adultClients)
        {
            var adults = clients.Where(x => x.Age > 20);
            foreach (var client in adults)
                adultClients.Add(client);
        }
        static void ForEachWithoutVariable(List<Person> clients, List<Person> adultClients)
        {
            foreach (var client in clients.Where(x => x.Age > 20))
                adultClients.Add(client);
        }
    }
    class Person
    {
        public int Age { get; set; }
    }
