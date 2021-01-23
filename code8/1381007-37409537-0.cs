    [XmlInclude(typeof(SubscriptionEvent))]
    [XmlRoot(Namespace = "http://schema.broadsoft.com/xsi")]
    public abstract class Event
    {
    }
    [XmlType(Namespace = "http://schema.broadsoft.com/xsi")]
    public class SubscriptionEvent : Event
    {
        [XmlElement(ElementName = "eventID")]
        public string EventID { get; set; }
        [XmlElement(ElementName = "sequenceNumber")]
        public string SequenceNumber { get; set; }
        [XmlElement(ElementName = "userId")]
        public string UserId { get; set; }
        [XmlElement(ElementName = "externalApplicationId")]
        public string ExternalApplicationId { get; set; }
        [XmlElement(ElementName = "subscriptionId")]
        public string SubscriptionId { get; set; }
        [XmlElement(ElementName = "channelId")]
        public string ChannelId { get; set; }
        [XmlElement(ElementName = "targetId")]
        public string TargetId { get; set; }
        [XmlElement(ElementName = "eventData")]
        public EventData EventData { get; set; }
    }
    [XmlInclude(typeof(ACDSubscriptionEvent))]
    public abstract class EventData
    {
    }
    [XmlType(Namespace = "http://schema.broadsoft.com/xsi")]
    public class ACDSubscriptionEvent : EventData
    {
    }
