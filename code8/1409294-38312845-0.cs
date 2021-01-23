    public class Course
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
       
        [Key, Column(Order = 1)]
        public int? CourseID { get; set; }
   
        public string CourseName { get; set; }
    }
    public class Student
    {
        [Key]
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        public int? CourseID { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }
    }
