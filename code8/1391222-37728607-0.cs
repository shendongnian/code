    public class USER
    {
        public string result_id { get; set; }
        public string result_description { get; set; }
        public List<string> cmlog_username { get; set; }
        public List<string> caller_id { get; set; }
    }
    
    public class RootObject
    {
        public USER USER { get; set; }
    }
