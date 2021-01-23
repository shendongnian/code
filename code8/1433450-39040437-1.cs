    public class Rootobject
    {
        public List<Names> cols { get; set; }
        public List<Row> rows { get; set; }
    }
    
    public class Names
    {
        public string label { get; set; }
        public string type { get; set; }
    }
    
    public class Row
    {
        public List<C> c { get; set; }
    }
    
    public class C
    {
        public string v { get; set; }
    }
