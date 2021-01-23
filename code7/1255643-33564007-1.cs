    public class DesignationHierarchy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal LineManagerId { get; set; }
    
    }
    public class EmployeeInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public string Name { get; set; }
    
    }
