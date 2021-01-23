    public class EmailData
    {
        [JsonProperty(Required = Required.Always)] // Must be present and non-null
        public string UserId { get; set; }
        [JsonProperty(Required = Required.Always)] // Must be present and non-null
        public string Username { get; set; }
        [JsonProperty(Required = Required.AllowNull)] // Must be present but can be null
        public string Email { get; set; }
    }
