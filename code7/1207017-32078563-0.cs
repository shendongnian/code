    public class Son
    {
        public string name { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
    }
    public class RootObject
    {
        public string name { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public List<Son> Sons { get; set; }
    }
