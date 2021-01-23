    class School
    {
        private IList<Student> students;
        public ReadOnlyCollection<Student> Students
        {
            get
            {
                return this.students.AsReadOnly()
            }
            private set;
        }
    }
