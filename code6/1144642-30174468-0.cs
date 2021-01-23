    public class Json
    {
        public string Item { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Quantity { get; set; }
    }
    
    public class RootObject
    {
        public List<Json> json { get; set; }
    }
