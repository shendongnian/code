    public class MyDocument
    {
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set;}
    
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTimeOffset DateTimeOffset { get; set; }
    
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime? NullableDateTime { get; set; }
    
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTimeOffset? NullableDateTimeOffset { get; set; }
    }
