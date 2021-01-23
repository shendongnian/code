    public class Property
    {
        public int AppVersionIOS { get; set; }
        public int AppVersionAndroid { get; set; }
    }
    
    public class RootObject
    {
        public string __invalid_name__@class { get; set; }
        public Property property { get; set; }
        public string requestId { get; set; }
        public object scriptData { get; set; }
    }
