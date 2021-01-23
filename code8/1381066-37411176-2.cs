    public class Result
    {
    
    	[JsonProperty("definition")]
    	public string Definition { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("permalink")]
        public string PermaLink { get; set; }
    
    }
    
    public class Results
    {
    
    	[JsonProperty("list")]
    	public List<Result> List { get; set; }
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
     
    }
