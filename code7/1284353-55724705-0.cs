    [DataContract]
    [Serializable]
    public class EventMessageDto
    {
        [DataMember]
        public Guid EventId { get; set; }
        
        [DataMember]
        public string EventType { get; set; }
    
        [DataMember]
        public string EventData { get; set; }
    }
