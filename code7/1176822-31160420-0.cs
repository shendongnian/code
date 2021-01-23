    public class EmployeeModel
        {
            [Key]
            public int ID { get; set; }
            public int DeptID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string City { get; set; }     
    
            [ForeignKey("DeptID")]
            public virtual DepartmentModel DID { get; set; }
    
        }
