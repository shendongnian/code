    [XmlRoot("Order")]
    public class Order
    {
        [XmlIgnore]
        [JsonProperty("CardNumber")]
        public Guid? CardNumber { get; set; }
        [XmlElement(ElementName = "CardNumber", IsNullable = true)]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [JsonIgnore]
        public string XmlCardNumber
        {
            get
            {
                if (CardNumber == null)
                    return null;
                else if (CardNumber.Value == Guid.Empty)
                    return "";
                return XmlConvert.ToString(CardNumber.Value);
            }
            set
            {
                if (value == null)
                    CardNumber = null;
                else if (string.IsNullOrEmpty(value))
                    CardNumber = Guid.Empty;
                else
                    CardNumber = XmlConvert.ToGuid(value);
            }
        }
    }
