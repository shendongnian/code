    [Serializable]
    public class Sample : IXmlSerializable
    {
        public string Something { get; set; }
        public List<Parameter> Parameters { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.ReadString();
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("Something", this.Something);
            writer.WriteStartElement("Parameters");
            foreach (var parameter in Parameters)
            {
                writer.WriteElementString(parameter.Name, parameter.Value);
            }
            writer.WriteEndElement();
        }
    }
