    public class Student
    {
        private Student()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
