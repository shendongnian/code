    public class Result
    {
        public List<TableA> A { get; set; }
    }
    public class TableA
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public float ppu { get; set; }
        public List<TableB> B { get; set; }
        public List<TableC> C { get; set; }
    }
    public class TableB
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    public class TableC
    {
        public string id { get; set; }
        public string type { get; set; }
    }
    
