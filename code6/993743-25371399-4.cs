    class Program
    {
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>
            {
                new Company
                {
                    Name = "Initrode Global",
                    Aliases = new List<string> { "Initech" },
                    Employees = new List<Employee>
                    {
                        new Employee(22, "Bill Lumbergh", new DateTime(2005, 3, 25)),
                        new Employee(87, "Peter Gibbons", new DateTime(2011, 6, 3)),
                        new Employee(91, "Michael Bolton", new DateTime(2012, 10, 18)),
                    }
                },
                new Company
                {
                    Name = "Contoso Corporation",
                    Aliases = new List<string> { "Contoso Bank", "Contoso Pharmaceuticals" },
                    Employees = new List<Employee>
                    {
                        new Employee(23, "John Doe", new DateTime(2007, 8, 22)),
                        new Employee(61, "Joe Schmoe", new DateTime(2009, 9, 12)),
                    }
                }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new ListCompactionConverter());
            settings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd-MMM-yyyy" });
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(companies, settings);
            Console.WriteLine(json);
            Console.WriteLine();
            List<Company> list = JsonConvert.DeserializeObject<List<Company>>(json, settings);
            foreach (Company c in list)
            {
                Console.WriteLine("Company: " + c.Name);
                Console.WriteLine("Aliases: " + string.Join(", ", c.Aliases));
                Console.WriteLine("Employees: ");
                foreach (Employee emp in c.Employees)
                {
                    Console.WriteLine("  Id: " + emp.Id);
                    Console.WriteLine("  Name: " + emp.Name);
                    Console.WriteLine("  HireDate: " + emp.HireDate.ToShortDateString());
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
    class Company
    {
        public string Name { get; set; }
        [JsonProperty("Doing Business As")]
        public List<string> Aliases { get; set; }
        public List<Employee> Employees { get; set; }
    }
    class Employee
    {
        [JsonConstructor]
        public Employee(int id, string name, DateTime hireDate)
        {
            Id = id;
            Name = name;
            HireDate = hireDate;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime HireDate { get; private set; }
    }
