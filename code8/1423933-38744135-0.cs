    public class Type
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool closedQuestion { get; set; }
        public bool multiAnswer {get; set;}
        public bool usesImage {get; set; }
    }
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public Type type { get; set; }
        public List<string> options { get; set; }
    }
