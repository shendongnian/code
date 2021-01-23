    internal class RequestData
    {
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal string RequestHeader { get; set; }
    
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal IRequestPayload RequestPayload { get; set; }
    }
