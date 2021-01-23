    private List<Student> AllStudents = new List<Student>();
        public Student()
        {
            AllStudents.Add(this);
        }
        public List<Student> AllStudentsList
        {
            get
            {
                return AllStudents;
            }
            set
            {
                AllStudents = value;
            }
        }
