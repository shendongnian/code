    [DebuggerDisplay("{Value}")]
    public class XmlDateTime : IXmlSerializable
    {
        public DateTime Value { get; set; }
        public bool HasValue { get { return Value != DateTime.MinValue; } }
        private const string XML_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ssZ";
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.ReadStartElement();
                return;
            }
            string someDate = reader.ReadInnerXml();
            if (String.IsNullOrWhiteSpace(someDate) == false)
            {
                Value = XmlConvert.ToDateTime(someDate, XML_DATE_FORMAT);
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (Value == DateTime.MinValue)
                return;
            writer.WriteRaw(XmlConvert.ToString(Value, XML_DATE_FORMAT));
        }
        public static implicit operator DateTime(XmlDateTime custom)
        {
            return custom.Value;
        }
        public static implicit operator XmlDateTime(DateTime custom)
        {
            return new XmlDateTime() { Value = custom };
        }
    }
