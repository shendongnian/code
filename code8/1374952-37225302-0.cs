        public class Year
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }
    }
    
    public class Employee
    {
        public Year Year { get; set; }
    }
    
    public class RootObject
    {
        public Employee Employee { get; set; }
    }
