    public class Page
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
    }
    public class Query
    {
        public Dictionary<string,Page> pages { get; set; }
    }
    public class WiktionaryResponse
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
    }
