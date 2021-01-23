    public class Data
    {
        public string name { get; set; }
        public ChangedBy changed_by { get; set; }
    }
    
    public class ChangedBy
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
