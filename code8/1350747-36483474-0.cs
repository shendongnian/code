    public class Tutor
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
    }
    
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class CourseModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string duration { get; set; }
        public string description { get; set; }
        public Tutor tutor { get; set; }
        public Subject subject { get; set; }
    }
