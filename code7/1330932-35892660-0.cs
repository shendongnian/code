        private static void Main()
        {
            List<Boss> BossList = new List<Boss>()
            {
                new Boss()
                {
                    EmpID = 101,
                    Name = "Harry",
                    Department = "Development",
                    Gender = "Male",
                    Employees = new List<Person>()
                    {
                        new Person() {EmpID = 102, Name = "Peter", Department = "Development", Gender = "Male"},
                        new Person() {EmpID = 103, Name = "Emma Watson", Department = "Development", Gender = "Female"},
                    }
                },
                new Boss()
                {
                    EmpID = 104,
                    Name = "Raj",
                    Department = "Development",
                    Gender = "Male",
                    Employees = new List<Person>()
                    {
                        new Person() {EmpID = 105, Name = "Kaliya", Department = "Development", Gender = "Male"},
                        new Person() {EmpID = 103, Name = "Emma Watson", Department = "Development", Gender = "Female"},
                    }
                }
            };
            Random r = new Random();
            var genders = new [] {"Male", "Female"};
            for (int i = 0; i < 1000000; i++)
                BossList.First().Employees.Add(new Person { Name = "Name" + i, Department = "Department" + i, Gender = genders[r.Next(0, 1)], EmpID = 200 + i });
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            Dictionary<string,Person> staffList = BossList
                .SelectMany(x =>
                    new[] {new Person {Name = x.Name, Department = x.Department, Gender = x.Gender, EmpID = x.EmpID}}
                        .Concat(x.Employees))
                .GroupBy(x => x.EmpID) //Group by employee ID
                .Select(g => g.First()) //And select a single instance for each unique employee
                .ToDictionary(p => p.Name.ToLowerInvariant() + p.EmpID);
            Console.WriteLine("Time to load staffList = " + sw.ElapsedMilliseconds + "ms");
            var rajKeyText = "Raj".ToLowerInvariant();
            var raj = staffList.FirstOrDefault(kvp => kvp.Key.Contains(rajKeyText));
            Console.WriteLine("Time to find Raj = " + sw.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }
        public class Person
        {
            public int EmpID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Gender { get; set; }
        }
        public class Boss
        {
            public int EmpID { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public string Gender { get; set; }
            public List<Person> Employees { get; set; }
        }
    }
