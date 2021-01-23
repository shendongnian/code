    //generated with json2csharp
    public class Self
    {
        public string href { get; set; }
    }
    
    public class Links
    {
        public Self self { get; set; }
    }
    
    public class Item
    {
        public int id { get; set; }
        public string shortname { get; set; }
        public Links _links { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
