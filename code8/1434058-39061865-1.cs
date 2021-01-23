    public class ResultArray
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public int success { get; set; }
        public string message { get; set; }
        public List<T> resultArray { get; set; }
    }
