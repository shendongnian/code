    [Serializable]
    public class TestA : IXmlSerializable
    {
        public object value;
        public XmlSchema GetSchema()
        {
            return (null);
        }
        public void ReadXml(XmlReader reader)
        {
            value = reader.ReadContentAsObject();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(value);
        }
    }
