    public class EmployeeDetails
    {
        public int EmployeeDetailsId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
                
        public virtual EmployeeDetails Manager { get; set; }
        [ForeignKey("LineManager")]
        public int? LineManagerId { get; set; }
        public virtual EmployeeDetails LineManager { get; set; }
        [ForeignKey("ManagerId")]
        public virtual ICollection<EmployeeDetails> ManagedEmployees { get; set; }
        [ForeignKey("LineManagerId")]
        public virtual ICollection<EmployeeDetails> LineManagedEmployees { get; set; }
    }
