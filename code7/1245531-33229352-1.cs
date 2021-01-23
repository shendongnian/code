     public class Employee
      {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
	  }
 
    public class EmployeeDetail
      {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public string Adress { get; set; }
   
        public virtual Employee Employee { get; set; }
      }
