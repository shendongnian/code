    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
    
        public virtual Staff Staff{ get; set; }
    }
