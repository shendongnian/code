    class School
    {
        private List<Student> students;
        public List<Student> Students
        {
            get
            {
                return this.students.AsReadOnly()
            }
            private set;
        }
    }
