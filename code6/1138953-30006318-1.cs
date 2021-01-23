    public class StudentDto
    {
        public int student_id { get; set; }
        public int user_id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public int rollno { get; set; }
        public string class_id { get; set; }
        public string school_id { get; set; }
        public string address { get; set; }
        public string remarks { get; set; }
        public string date_created { get; set; }
    }
    
    public class RootObject
    {
        public string user_id { get; set; }
        public string school_id { get; set; }
        public string user_name { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string type { get; set; }
        public string phoneno { get; set; }
        public string mobileno { get; set; }
        public string address { get; set; }
        public string relation { get; set; }
        public string date_created { get; set; }
        public StudentDto student_dto { get; set; }
    }
