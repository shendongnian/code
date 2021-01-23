    public class Settings
        {
            [JsonProperty("assets.last_updated_at")]
            public string assets_last_updated_at { get; set; }
    
            [JsonProperty("data.version")]
            public int data_version { get; set; }
           // Add other property here...
        }
    
        public class RootObject
        {
            public Settings settings { get; set; }
        }
