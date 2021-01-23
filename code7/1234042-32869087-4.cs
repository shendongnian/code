    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string number { get; set; }
    }
    
    public class Success
    {
        public string id { get; set; }
        public string device_id { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public string send_at { get; set; }
        public string queued_at { get; set; }
        public string sent_at { get; set; }
        public string delivered_at { get; set; }
        public string expires_at { get; set; }
        public string canceled_at { get; set; }
        public string failed_at { get; set; }
        public string received_at { get; set; }
        public string error { get; set; }
        public string created_at { get; set; }
        public Contact contact { get; set; }
    }
    
    public class Errors
    {
        public List<string> device { get; set; }
    }
    
    public class Fail
    {
        public string number { get; set; }
        public string message { get; set; }
        public int device { get; set; }
        public Errors errors { get; set; }
    }
    
    public class Result
    {
        public List<Success> success { get; set; }
        public List<Fail> fails { get; set; }
    }
    
    public class RootObject
    {
        public bool success { get; set; }
        public Result result { get; set; }
    }
