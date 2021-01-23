    public class MyObject
    {
        public string Description { get; set; }
        [JsonProperty(PropertyName="public")]
        public bool IsPublic { get; set; }
        public Dictionary<string, JObject> Files { get; set; }
    }
