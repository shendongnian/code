    public class TheData
    {
    	[JsonProperty("first.name")]
        public string FirstName { get; set; }
    	[JsonProperty("last.name")]
        public string LastName { get; set; }
    }
    
    public class RootObject
    {
    	[JsonProperty("the.data")]
        public TheData TheData { get; set; }
    }
