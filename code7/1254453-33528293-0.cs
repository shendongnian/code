    public class Employee
    {
        public Employee(string name)
        {
            Name = name;
            Degress = new HashSet<string>();
        }
        public string Name { get; private set; }
        public HashSet<string> Degrees { get; private set; }
    }
