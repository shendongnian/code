    // Deserialize requests into this.
    public class EntityRequest
    {
        [JsonProperty("entity")]
        private string EntityIdentifier { get; set; }
    }
    // Serialize these to file/etc.
    public class EntityData
    {
        [JsonProperty("entity")]
        public EntityObject Entity { get; set; }
    }
