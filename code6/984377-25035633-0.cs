    public class Student : Person
    {
        public Student(string path = null) : base(path)
        {
    
        }
    }
    
    public class Person
    {
        public Person(string path = null)
        {
            path = path ?? "sensible default";
        }
    }
