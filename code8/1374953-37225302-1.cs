        public class Year
    {
        public int StartRange { get; set; }
        public int EndRange { get; set; }
    }
    
    public class Employee
    {
        public List<Year> Year { get; set; }
    }
    
    public class RootObject
    {
        public List<Employee> Employee { get; set; }
    }
