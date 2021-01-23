    public class Student
    {
        public int CourseId { get; set; }
        public int OpenCourseId { get; set; }
        public virtual Course Course { get; set; }
    }
