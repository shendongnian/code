    public class Settings
        {
            [JsonProperty(PropertyName = "mode")]
            public string Mode { get; set; }
            [JsonProperty(PropertyName = "format")]
            public string OutputFormat { get; set; }
            [JsonIgnoreAttribute]
            public string Options { get; private set; }
            [JsonProperty(PropertyName = "options")]
            private object Temp { get; set; }
            [OnDeserialized]
            private void OnDeserialized(StreamingContext ctx)
            {
                Options = Temp?.ToString();
            }
        }
