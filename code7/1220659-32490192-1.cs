    public class Department 
    { 
        // Primary key 
        public int DepartmentID { get; set; } 
        public string Name { get; set; } 
     
        // Navigation property 
        public virtual ICollection<Course> Courses { get; set; } 
    } 
     
    public class Course 
    { 
        // Primary key 
        public int CourseID { get; set; } 
     
        public string Title { get; set; } 
        public int Credits { get; set; } 
     
        // Foreign key 
        public int DepartmentID { get; set; } 
     
        // Navigation properties 
        public virtual Department Department { get; set; } 
    }
