     public class Data
        {
            [JsonProperty(PropertyName = "warning")]
            public string Warning { get; set; }
        }
        public class Error
        {
            [JsonProperty(PropertyName = "373")]
            public string Col_373 { get; set; }
        }
    
        public class ApiResponse
        {
            [JsonProperty(PropertyName = "status")]
            public string Status { get; set; }
            [JsonProperty(PropertyName = "data")]
            public List<Data> Data { get; set; }
            [JsonProperty(PropertyName = "error")]
            public List<Error> Error { get; set; }
        }
