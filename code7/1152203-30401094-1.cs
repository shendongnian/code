    class University
    {
        public int NumbersOfStudents { get; private set; }
        
        public Student[] students;
        public University()
        {
            NumberOfStudents = numberOfStudents;
            students = new Student[numberOfStudents];
        }
    }
