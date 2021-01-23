    public class Child
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int refereceId { get; set; }
        public List<Child> childs { get; set; }
    }
    
    public class EducationDetail
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int refereceId { get; set; }
        public List<Child> childs { get; set; }
    }
    
    public class RootObject
    {
        public bool result { get; set; }
        public List<EducationDetail> education_details { get; set; }
    }
