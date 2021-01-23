    public class Employee
    {
        public int Id { get; set; }
        //.... Other employee properties like name, last name, etc...
    
       public int CompanyId {get; set;}
       [ForeignKey("CompanyId")]
       public Company Company { get; set;}
    }
    public class Company 
    {
       public int Id { get; set; }
       //.... Other company properties like name, type, etc...
    
       public virtual ICollection<Employee> Employees { get; set; }
    }
