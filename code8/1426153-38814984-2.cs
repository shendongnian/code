    public class School 
    {
        public long SchoolId { get; set; }
        public long? StudentId { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public long? TeacherId { get; set; }
    }
    
    public class Student 
    {
        public long StudentId { get; set; }
        public string name { get; set; }
    }
    
    public class Teacher 
    {
        public long TeacherId { get; set; }
        public string name { get; set; }
    }
