    public class Root
    {
        [JsonProperty("user_data")]
        public Dictionary<string, User> Users { get; set; }
    }
