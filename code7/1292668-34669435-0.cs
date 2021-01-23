    public class Tree
    {
        public Page page { get; set; }
    }
    public class Page
    {
        public List<Result> results { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
    }
    public class Result
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
    }
    
 
