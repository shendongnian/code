    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }    
        public int DepartmentId { get; set; } <=== 
                
        // Optional, but good practice to have this data annotation attribute. 
        [ForeignKey("DepartmentId")] <=== 
        public Department Department { get; set; }
    }
