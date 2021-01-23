        [XmlRoot("string-wrapper")]
        public class CustomString : IXmlSerializable
        {
            public string Value { get; set; }
        
            public XmlSchema GetSchema()
            {
                return null; // GetSchema should not be used.
            }
            public void ReadXml(XmlReader reader)
            {
                Value = reader.ReadString();
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteString(Value);
            }
        }
