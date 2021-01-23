    class University
    {
        public int NumbersOfStudents { get; private set; }
        
        public Student[] students;
        public University(int numberOfStudents)
        {
            NumberOfStudents = numberOfStudents;
            students = new Student[numberOfStudents];
        }
    }
