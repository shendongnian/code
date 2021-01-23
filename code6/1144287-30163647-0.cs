    public class List
    {
        public string a { get; set; }
        public string b { get; set; }
    }
    public class RootObject
    {
        public string _id { get; set; }
        public List<string> r { get; set; }
        public List<List> list { get; set; }
    }
