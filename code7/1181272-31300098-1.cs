    public class Address 
    {
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    
    public class StudentViewModel
    {
        public StudentViewModel ()
    	{
            Student = new Student();
            Address = new Address();
    	}
        public Student Student { get; set; }
        public Address Address { get; set; }
    
    }
