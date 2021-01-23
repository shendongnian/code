    class School
    {
        private List<Student> students;
        public ReadOnlyCollection<Student> Students
        {
            get
            {
                return this.students.AsReadOnly()
            }
            private set;
        }
    }
