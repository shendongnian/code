	public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }
        [JsonProperty("@encoding")]
        public string Encoding { get; set; }
    }
    public class Issuer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
    public class DataFeed
    {
        [JsonProperty("@FeedName")]
        public string FeedName { get; set; }
        [JsonProperty("Issuer")]
        public Issuer Issuer { get; set; }
    }
    public class RootJsonObject
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }
        [JsonProperty("DataFeed")]
        public DataFeed DataFeed { get; set; }
    }
	
