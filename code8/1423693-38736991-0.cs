    internal sealed class Course
    {
        private ICollection<Student> students;
        public ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = Students; }
        }
        public Course()
        {
            this.Students = new List<Student>();
        }
    }
