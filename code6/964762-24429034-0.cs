    public class Student 
    {
       public string Name { get; set;}
       public List<Course> Courses { get; set; }
    }
    
    public class Course
    {
       public string Name { get; set;}
    }
    
    public class MySettings
    {
        public List<Student> Students {get; set;}
    }
