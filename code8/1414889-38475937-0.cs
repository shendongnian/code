    public class Retail
    {
        public string __invalid_name__@xsi.type { get; set; }
        public string clientuuid { get; set; }
        public int deviceuuid { get; set; }
    }
    
    public class Result
    {
        public Retail retail { get; set; }
        public bool success { get; set; }
    }
    
    public class RootObject
    {
        public Result result { get; set; }
    }
