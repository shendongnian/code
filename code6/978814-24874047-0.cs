    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    public class Adult : Person
    {
        public string Workplace { get; set; }
    }
    public class Child : Person
    {
        public List<string> Toys { get; set; }
    }
