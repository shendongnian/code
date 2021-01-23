    public class Type
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string lastUpdated { get; set; }
    }
    
    public class Tester
    {
        public Type type { get; set; }
        public object specification { get; set; }
    }
    
    public class RootObject
    {
        public List<Tester> tester { get; set; }
    }
