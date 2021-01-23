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
            reader.ReadStartElement("Sample");
            Something = reader.ReadElementString("Something");
            reader.ReadStartElement("Parameters");
            Parameters = new List<Parameter>();
            var subTree = reader.ReadSubtree();
            while (subTree.Read())
            {
                if (subTree.NodeType == XmlNodeType.Text)
                {
                    var nm = subTree.LocalName;
                    Parameters.Add(new Parameter {Name = nm, Value = subTree.Value});
                }
            }
            reader.ReadEndElement();
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
