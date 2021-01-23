        public class Request
        {
            public Request() { }
            [JsonIgnore]
            private string EntityIdentifier { get; set; }
            [JsonProperty("entity")]
            public EntityObject Entity { get; set; }
        }
