    public class Child2
    {
        public string id { get; set; }
        public string cx { get; set; }
        public string cy { get; set; }
    }
    
    public class Child
    {
        public string id { get; set; }
        public string tag { get; set; }
        public string value { get; set; }
        public List<Child2> children { get; set; }
    }
    
    public class RootObject
    {
        public string id { get; set; }
        public List<Child> children { get; set; }
    }
