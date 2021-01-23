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
                reader.MoveToContent();
                bool isEmpty = reader.IsEmptyElement;
                reader.ReadStartElement();
                if (!isEmpty)
                {
                    Value = reader.ReadString();
                    reader.ReadEndElement();
                }
            }
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteString(Value);
            }
        }
