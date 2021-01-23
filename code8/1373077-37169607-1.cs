    class School
    {
        private readonly List<Student> _students = new List<Student>();
        public ReadOnlyCollection<Student> Students
        {
            get { return _students.AsReadOnly(); }
        }
    }
