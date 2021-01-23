    public class Type
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string lastUpdated { get; set; }
    }
    
    public class Specification
    {
        public string ID { get; set; }
        public int number { get; set; }
        public string Type { get; set; }
    }
    
    public class Tester
    {
        public Type type { get; set; }
        public List<Specification> specification { get; set; }
    }
    
    public class RootObject
    {
        public List<Tester> tester { get; set; }
    }
