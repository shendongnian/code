    public class Child2
    {
        public int id { get; set; }
    }
    
    public class Child
    {
        public int id { get; set; }
        public List<Child2> children { get; set; }
    }
    
    public class RootObject
    {
        public int id { get; set; }
        public List<Child> children { get; set; }
    }
