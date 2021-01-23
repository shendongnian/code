    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
