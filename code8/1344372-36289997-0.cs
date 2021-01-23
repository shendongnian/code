    public class InnerObject
    {
        public string name { get; set; }
        public DateTime time { get; set; }
        public string id { get; set; }
        public string code { get; set; }
    }
    public class RootObject
    {
        public List<List<InnerObject>> rows { get; set; }
    }
