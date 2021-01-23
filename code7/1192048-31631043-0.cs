    public class Employee
    {
        public int EmployeeId { get; set; }
    
        [ForeignKey("Company"),Column("Company_CompanyId")]
        public int CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
    }
