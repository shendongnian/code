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
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            Something = doc.SelectSingleNode(@"/Sample/Something").FirstChild.Value;
            var parameters = doc.SelectSingleNode(@"/Sample/Parameters");
            if (parameters.HasChildNodes)
            {
                Parameters = new List<Parameter>();
                foreach (XmlElement childNode in parameters.ChildNodes)
                {
                    Parameters.Add(new Parameter {Name = childNode.LocalName, Value = childNode.FirstChild.Value});
                }
            }
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
