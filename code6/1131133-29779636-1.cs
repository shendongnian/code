    public class Student
    {
        public string FullName { get; set; }
        public int StudentID { get; set; }
        private static int _currentId = 1000;
        public Student(string name)
        {
            FullName = name;
            StudentID = _currentId++;
            return;
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\n Name: {1}", StudentID, FullName);
        }
    }
