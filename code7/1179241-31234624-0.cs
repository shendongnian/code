    public class Issue
    {
        public Issue()
        {
            this.Fields = new Dictionary<string, CustomField>();
        }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("fields")]
        public Dictionary<string, CustomField> Fields { get; set; }
    }
