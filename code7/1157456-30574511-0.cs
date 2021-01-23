    public interface IName
    {
        string Name { get; }
    }
    class Person : IName
    {
        public string Name { get; set; }
        public string Car { get; set; }
    }
    class Employee : IName
    {
        public string Name { get; set;}
        public string Salary { get; set;}
    }
