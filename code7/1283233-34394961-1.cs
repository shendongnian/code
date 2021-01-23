    public class Context
    {
        [JsonProperty("item")]
        public ContextItem Item { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
    }
