    public class PropertyChange
    {
        [JsonProperty("name")]
        public string PropertyName { get; set; }
        [JsonProperty("value")]
        public string PropertyValue { get; set; }
        [JsonProperty("arrayValue")]
        public dynamic[] PropertyArray { get; set; }
    }
