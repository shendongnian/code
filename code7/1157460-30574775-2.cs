    public class Person
    {
        public string Name { get; set; }
        public string Car { get; set; }
        public Job Job { get; set; }
    }
    public class Job
    {
        public string Salary { get; set;}
        public Person Employee { get; set; }    
    }
    
