    // as is
    public class Teacher
    {
        public virtual ISet<Student> Students {get;set;}
        // ...
    }
    
    // has reference to Teacher
    public class Student
    {
        public virtual Teacher Teacher {get;set;}
        // ... 
    }
