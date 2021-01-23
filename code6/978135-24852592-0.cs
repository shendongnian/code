    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
        public List<Subject> Subjects { get; private set; }
    }
    
    class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    
        public List<Student> Students { get; private set; }
    }
