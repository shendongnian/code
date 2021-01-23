    [Table("Employee")] //can be Employees
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLenth(64)]
        public string FirstName { get; set; }
        [StringLenth(64)]
        public string LastName { get; set; }
        public virtual ICollection<Complaint> Complaints { get; set; } 
    }    
    [Table("Complaint")] //can be Complaints
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        [StringLenth(128)]
        public string Description { get; set; } 
        public virtual ICollection<Employee> Employees { get; set; }
    }
