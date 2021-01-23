        private static void Main()
        {
            List<Boss> BossList = new List<Boss>();
            var b1 = new Boss()
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
            };
            var b2 = new Boss()
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
            };
            Random r = new Random();
            var genders = new [] {"Male", "Female"};
            for (int i = 0; i < 1500000; i++)
            {
                b1.Employees.Add(new Person { Name = "Name" + i, Department = "Department" + i, Gender = genders[r.Next(0, 1)], EmpID = 200 + i });
                b2.Employees.Add(new Person { Name = "Nam" + i, Department = "Department" + i, Gender = genders[r.Next(0, 1)], EmpID = 1000201 + i });
            }
            BossList.Add(b1);
            BossList.Add(b2);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var emps = BossList
                .SelectMany(x =>
                    new[] {new Person {Name = x.Name, Department = x.Department, Gender = x.Gender, EmpID = x.EmpID}}
                        .Concat(x.Employees))
                .GroupBy(x => x.EmpID) //Group by employee ID
                .Select(g => g.First());
            var staffList =  emps.ToList();
            var staffDict = emps.ToDictionary(p => p.Name.ToLowerInvariant() + p.EmpID);
            var staffSortedList = new SortedList<string, Person>(staffDict);
            
            Console.WriteLine("Time to load staffList = " + sw.ElapsedMilliseconds + "ms");
            var rajKeyText = "Raj".ToLowerInvariant();
            sw.Reset();
            sw.Start();
            var rajs1 = staffList.AsParallel().Where(p => p.Name.ToLowerInvariant().Contains(rajKeyText)).ToList();
            Console.WriteLine("Time to find Raj = " + sw.ElapsedMilliseconds + "ms");
            
            sw.Reset();
            sw.Start();
            var rajs2 = staffDict.AsParallel().Where(kvp => kvp.Key.Contains(rajKeyText)).ToList();
            Console.WriteLine("Time to find Raj = " + sw.ElapsedMilliseconds + "ms");
            sw.Reset();
            sw.Start();
            var rajs3 = staffSortedList.AsParallel().Where(kvp => kvp.Key.Contains(rajKeyText)).ToList();
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
