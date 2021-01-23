    public abstract class BaseNotification
    {
        [JsonProperty(PropertyName = "$type")]
        public abstract string RdfType { get; }
        public string ConsumerId { get; set; }
        public Guid ChannelId { get; set; }
    }
