    [JsonConverter(typeof(CustomCoverter))]
    [DataContract]
    public class PriceHistoryRecordModel
    {
        [DataMember]
        public DateTime Date { get; set; }
    
        [DataMember]
        public double Value { get; set; }
    }
