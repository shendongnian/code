    public class Products
    {
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public string name {get; set;}
        
        [JsonProperty]
        public string CustomName {get; set;}
    }
