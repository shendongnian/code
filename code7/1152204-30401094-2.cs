    class University
    {
        public List<Student> Students {get; private set; }
        public University(int numberOfStudents)
        {
            Students = new List<Student>();
        }
    }
