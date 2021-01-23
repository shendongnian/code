    public class connections
    {
        public string start { get; set; }
        public string end { get; set; }
    }
    public class chartItem
    {
            public string id { get; set; }
            public string type { get; set; }
            public int left { get; set; }
            public int top { get; set; }
    
            public string content { get; set; }
    }
    // holding both chartItems and nodes
    public class ChartJson
    {
            public List<connections> connections { get; set; }
            public List<chartItem> nodes { get; set; }
    }
