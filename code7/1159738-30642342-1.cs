    public class Result
    {
        public List<TableA> A { get; set; }
    }
    public class TableA
    {
        public TableA()
        {
              B = new List<TableB>();
              C = new List<TableC>();
        }
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public float ppu { get; set; }
        public virtual List<TableB> B { get; set; }
        public virtual List<TableC> C { get; set; }
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
    
