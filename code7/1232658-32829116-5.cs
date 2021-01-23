    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "buyer-accepts-marketing")]
        public bool BuyerAcceptsMarketing { get; set; }
        [XmlIgnore]
        public DateTime? ClosedAt { get; set; }
        [XmlElement("closed-at")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string XmlDateTime
        {
            get
            {
                return ClosedAt == null ? null : XmlConvert.ToString(ClosedAt.Value, XmlDateTimeSerializationMode.Utc);
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    ClosedAt = null;
                else
                    ClosedAt = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
            }
        }
    }
