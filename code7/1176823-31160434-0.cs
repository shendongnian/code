    [Table("tblEmployees")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }     
        public int DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual DepartmentModel DID { get; set; }
    }
