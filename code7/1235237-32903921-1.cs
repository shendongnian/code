        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        class Manager
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            List<Person> ps = new List<Person>()
            {
                new Person() { Name ="Alex", Age = 30 },
                new Person() { Name ="Michael", Age = 22 }
            };
            List<Manager> mgr = ps.ConvertRange<Person, Manager>().ToList();
            foreach (var item in mgr)
                Console.WriteLine(item.Name + "   " + item.Age);
            Console.ReadKey();
       }
