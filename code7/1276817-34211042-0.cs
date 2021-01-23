    public interface IRequestPayload{}
    internal class RequestPayload1 : IRequestPayload
    {
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal string Date { get; set; }
    
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal string State { get; set; }
    
        [DataMember]
        [JsonProperty]
        internal string Properties { get; set; }
    }
    
    internal class RequestPayload2 : IRequestPayload
    {
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal string Id { get; set; }
    
        [DataMember]
        [JsonProperty(Required = Required.Always)]
        internal string Name { get; set; }
    
        [DataMember]
        [JsonProperty]
        internal string Location { get; set; }
    }
