    public class Uid
    {
        public string type { get; set; }
    }
    
    public class Properties2
    {
        public Uid uid { get; set; }
    }
    
    public class Items
    {
        public string type { get; set; }
        public Properties2 properties { get; set; }
    }
    
    public class Members
    {
        public string type { get; set; }
        public Items items { get; set; }
    }
    
    public class Uid2
    {
        public string type { get; set; }
    }
    
    public class Name
    {
        public string type { get; set; }
    }
    
    public class Properties
    {
        public Members members { get; set; }
        public Uid2 uid { get; set; }
        public Name name { get; set; }
    }
    
    public class RootObject
    {
        public string __invalid_name__$schema { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
    }
