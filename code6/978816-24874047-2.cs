    public interface IPerson
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; set; }
    }
    public class Adult : IPerson
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Workplace { get; set; }
    }
    public class Child : IPerson
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Toys { get; set; }
    }
