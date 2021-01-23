    internal class Student
    {
        public string Name { get; set; }
        
        public Student(string name)
        {
            this.Name = name;
        }
        public static List<Student> GenerateStudents()
        {
            var students= new List<Student>();
            students.Add(new Student("Jane"));
            students.Add(new Student("Alex"));
            students.Add(new Student("Mike"));
            students.Add(new Student("James"));
            students.Add(new Student("Julia"));
            return students;
        }
    }
