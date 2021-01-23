    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Student student = new Student();
                student.Name = "Joe";
    
                StudentSubClass studentSubClassed = new StudentSubClass();
                studentSubClassed.Name = ""; // THIS LINE IS DISALLOWED FOR COMPILATION.
    
                StudentWrapper studentWrapped = new StudentWrapper(student);
                studentWrapped.Name = ""; // THIS LINE IS DISALLOWED FOR COMPILATION.
    
                ReadOnlyStudent studentReadOnly = student as ReadOnlyStudent;
                if (studentReadOnly != null)
                {
                    studentReadOnly.Name = "";
                }
            }
        }
    
        class Student
        {
            public string Name { get; set; }
        }
    
        class StudentSubClass : Student
        {
            public new string Name { get; private set; }
        }
    
        class StudentWrapper
        {
            private Student student;
    
            public StudentWrapper(Student student)
            {
                this.student = student;
            }
    
            public string Name
            {
                get
                {
                    return this.student.Name;
                }
            }
        }
    }
