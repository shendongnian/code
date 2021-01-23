    namespace DataAccess
    {
        public class Course
        {
            public int CourseID { get; set; }
            public string Title { get; set; }
    
            public virtual ICollection<Lecture> Lectures { get; set; }
            public virtual ICollection<Tutor> Tutors { get; set; }
        }
        public class Lecture
        {
            public int LectureID { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public virtual ICollection<Student> Students { get; set; }
        }
        ...
    }
