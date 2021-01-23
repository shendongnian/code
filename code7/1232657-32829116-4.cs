    [XmlRoot(ElementName = "order")]
    public class Order
    {
        [XmlElement(ElementName = "buyer-accepts-marketing")]
        public bool BuyerAcceptsMarketing { get; set; }
        [XmlIgnore]
        public DateTime? ClosedAt { get; set; }
        [XmlElement("closed-at")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public XmlDateTimeWrapper XmlDateTime
        {
            get
            {
                return ClosedAt;
            }
            set
            {
                ClosedAt = value;
            }
        }
    }
    public class XmlDateTimeWrapper
    {
        public static implicit operator DateTime?(XmlDateTimeWrapper wrapper) { return wrapper == null ? null : wrapper.DateTime; }
        public static implicit operator XmlDateTimeWrapper(DateTime? dateTime) { return new XmlDateTimeWrapper { DateTime = dateTime }; }
        [XmlIgnore]
        public DateTime? DateTime { get; set; }
        [XmlText]
        public string DateTimeString
        {
            get
            {
                if (DateTime == null)
                    return string.Empty;
                return XmlConvert.ToString(DateTime.Value, XmlDateTimeSerializationMode.Utc);
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    DateTime = null;
                else
                    DateTime = XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
            }
        }
        [XmlAttribute("type")]
        public string Type { get { return "datetime"; } set { /* Do nothing */ } }
        [XmlAttribute("nil")]
        public bool Nil { get { return DateTime == null; } set { /* Do nothing */ } }
    }
