    public class LogItem
    {
        public string Name { get; set; }
        public LogItemType Type { get; set; }
        [XmlIgnore]
        public string Value { get; set; }
        [XmlElement("Value")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public XmlCharacterData ValueString
        {
            get
            {
                if (Value == null)
                    return null;
                else if (Type == LogItemType.Xml)
                    // return CDATA
                    return new XmlDocument().CreateCDataSection(Value);
                else
                    // return string (not CDATA)
                    return new XmlDocument().CreateTextNode(Value);
            }
            set
            {
                Value = value == null ? null : value.Value;
            }
        }
    }
