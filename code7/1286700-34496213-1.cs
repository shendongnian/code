    public class Log
    {
    
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string action { get; set; }
        public DateTime date { get; set; }
        public string fullname { set; get; }
    
        public Log(object myValue) {
          // your logic for myValue assignment to some property
        }
    }
