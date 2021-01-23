    public class StudentProgram
    {
        private readonly List<Student> _students = new List<Student>();
        public StudentProgram(string programName)
        {
            Name = programName;
        }
        public readonly string Name;
        public void AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
        }
        public IEnumerable<Student> AllStudents
        {
            get { return _students; }
        }
        public int NumberOfStudents
        {
            get { return _students.Count; }
        }
    }
