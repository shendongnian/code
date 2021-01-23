    class Program
    {
        static void Main(string[] args)
        {
            ChildDictionary dict = new ChildDictionary();
            dict.Name = "Roster";
            dict.Add(new Employee { Id = 22, Name = "Joe", HireDate = new DateTime(2012, 4, 17) }, 1923.07);
            dict.Add(new Employee { Id = 45, Name = "Fred", HireDate = new DateTime(2010, 8, 22) }, 1415.25);
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            Console.WriteLine(json);
            dict = JsonConvert.DeserializeObject<ChildDictionary>(json);
            Console.WriteLine("Name: " + dict.Name);
            foreach (var kvp in dict)
            {
                Console.WriteLine("Employee Id: " + kvp.Key.Id);
                Console.WriteLine("Employee Name: " + kvp.Key.Name);
                Console.WriteLine("Employee Hire Date: " + kvp.Key.HireDate);
                Console.WriteLine("Amount: " + kvp.Value);
                Console.WriteLine();
            }
        }
    }
    [JsonConverter(typeof(ComplexDictionaryConverter<Employee, double>))]
    public class ChildDictionary : Dictionary<Employee, double>
    {
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
