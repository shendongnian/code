    public class CustomObject : IXmlSerializable
    {
        private readonly Dictionary<String, String> attributes = new Dictionary<string, string>();
        public IDictionary<string, string> Attributes { get { return attributes; } }
        #region IXmlSerializable Members
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var element = XElement.ReadFrom(reader) as XElement;
            if (element != null)
            {
                foreach (var item in element.Elements())
                    attributes.Add(item.Name.LocalName, (string)item);
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            // Do NOT write the wrapper element when writing.
            foreach (var pair in attributes)
            {
                writer.WriteElementString(pair.Key, pair.Value);
            }
        }
        #endregion
    }
