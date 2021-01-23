    public class StudentWrapper
    {
        Student _student;
        public string Name { get { return _student.Name; } }
    
        public Student(Student student)
        {
            _student = student;
        }
    }
