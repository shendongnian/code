    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<Complaint> Complaints { get; set; } 
    }    
    public class Complaint
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public virtual ICollection<Employee> Employees { get; set; }
    }
