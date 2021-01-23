    public class Body
    {
        public string _id { get; set; }
        public Place place { get; set; }
        public int mark { get; set; }
        public Dictionary<string, SingleModule> measures { get; set; }
        public string[] modules { get; set; }
    }
