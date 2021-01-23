    public class Item
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }
    
    public class RootObject
    {
        public string title { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public List<Item> item { get; set; }
    }
