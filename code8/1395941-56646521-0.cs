    public class Student
     {
        public int id { get; set; }
        public string FullName { get; set; }
        public IList<CourseStudent> CourseStudents { get; set; }
     }
    public class Course
     {
        public int id { get; set; }
        public string CourseName { get; set; }
        public IList<CourseStudent> CourseStudents { get; set; }
     }
     
      //bridge Table
        public class CourseStudent
    {
        public Student Student { get; set; }
        [Key, Column(Order = 0)]
        public int Studentid { get; set; }
        public Course Course { get; set; }
        [Key, Column(Order = 1)]
        public int Courseid { get; set; }
        //You can add foreign keys like this
        //public Yourclass Yourclass{ get; set; }
        //[key, Column(Order = )]
        //public Yourclasstype(int,string or etc.) Yourclassid{ get; set; }
        //Other data fields
        public DateTime RegisterDate { get; set; }
    }
