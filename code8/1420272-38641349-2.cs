    [XmlRoot("Order")]
    public class Order
    {
        [XmlElement(Type = typeof(XmlGuid), ElementName = "CardNumber", IsNullable = true)]
        [JsonProperty("CardNumber")]
        public Guid? CardNumber { get; set; }
    }
