    public class Root {
        [JsonProperty("status")]
        public string Status {
            get;
            set;
        }
        [JsonProperty("resource")]
        public Dictionary<string, Dictionary<string, int>> Resource {
            get;
            set;
        }
    }
