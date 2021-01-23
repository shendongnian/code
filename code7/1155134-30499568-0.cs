    public class MySerializeableClass : IXmlSerializable
    {
        public bool IsActive { get; set; }
    
        public string AnyPath { get; set; }
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("AnyPath");
            writer.WriteAttributeString("IsActive", IsActive ? "true" : "false");
            writer.WriteString(AnyPath);
            writer.WriteEndElement();
        }
    }
