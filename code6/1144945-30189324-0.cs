    public class Staff
    {
        public int ID { get; set; }
    
        // other fields    
        
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
    }
