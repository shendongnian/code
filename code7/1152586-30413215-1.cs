    public class University
    {
        private readonly IList<Student> students = new List<Student>();
        // Presumably some other fields and properties
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
