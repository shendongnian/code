    public class pageval
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }
    
    
    public class Query
    {
        public Dictionary<string, pageval>  pages { get; set; }
    }
    
    public class Limits
    {
        public int extracts { get; set; }
    }
    
    public class RootObject
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
        public Limits limits { get; set; }
    }
