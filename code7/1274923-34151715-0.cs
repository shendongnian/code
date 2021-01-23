    public class Query
    {
       public Dictionary<string, object> pages { get; set; }
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
