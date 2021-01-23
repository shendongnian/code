    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    
        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }
        public virtual Departments department { get; set; }
    }
