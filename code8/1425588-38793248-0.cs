    public class Item322A
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public int prop3 { get; set; }
        public bool prop4 { get; set; }
    }
    
    public class Item2B
    {
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public int prop3 { get; set; }
        public bool prop4 { get; set; }
    }
    
    public class Items
    {
        public List<Item322A> Item322A { get; set; }
        public List<Item2B> Item2B { get; set; }
    }
    
    public class jsonObject
    {
        public Items Items { get; set; }
        public List<string> Errors { get; set; }
    }
