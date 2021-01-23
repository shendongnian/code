    public class Subject
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public virtual List<Student> Students {get;set;}
    }
    public class Student
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public virtual List<Subject> Subjects {get;set;}
    }
