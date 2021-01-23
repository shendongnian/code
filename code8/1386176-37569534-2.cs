    public class Employee
    {
        //add this property
        [ForeignKey("Department")]
        public int  DepartmentId { get; set; }
        public Department Department { get; set; }
    }
