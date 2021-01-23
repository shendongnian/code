    public class User
    {
        public long _id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Dictionary<string, string> _links { get; set; }
        public string display_name { get; set; }
        public object logo { get; set; }
        public object bio { get; set; }
        public string type { get; set; }
    }
    public class Follow
    {
        public DateTime created_at { get; set; }
        public Dictionary<string, string> _links { get; set; }
        public bool notifications { get; set; }
        public User user { get; set; }
    }
    public class RootObject
    {
        public RootObject()
        {
            this.follows = new List<Follow>();
        }
        public List<Follow> follows { get; set; }
        public int _total { get; set; }
        public Dictionary<string, string> _links { get; set; }
    }
