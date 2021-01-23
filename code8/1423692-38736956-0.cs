    internal sealed class Course
    {
        readonly List<Student> students = new List<Student>();
        public ICollection<Student> Students
        {
            get { return this.students; }
        }
    }
