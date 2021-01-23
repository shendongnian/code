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
            reader.Read();
            if (reader.Name == "AnyPath")
            {
                if (reader.HasAttributes)
                {
                    this.IsActive = string.Equals(reader.GetAttribute("IsActive"), "true", StringComparison.InvariantCultureIgnoreCase);
                }
                this.AnyPath = reader.ReadElementContentAsString();
                reader.ReadEndElement();
            }
            else
            {
                throw new FormatException();
            }
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("AnyPath");
            writer.WriteAttributeString("IsActive", IsActive ? "true" : "false");
            writer.WriteString(AnyPath);
            writer.WriteEndElement();
        }
    }
