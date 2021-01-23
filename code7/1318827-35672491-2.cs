    public class ResponseBase
        {
            public string ErrorReason { get; set; }
            [JsonIgnore] 
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public bool IsRejected { get; set; }
        }
