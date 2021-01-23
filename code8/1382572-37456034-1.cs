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
            // Do consume the wrapper element when reading.
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            using (var subReader = reader.ReadSubtree())
            {
                var element = XElement.Load(subReader);
                if (element != null)
                {
                    foreach (var item in element.Elements())
                        attributes.Add(item.Name.LocalName, (string)item);
                }
            }
            reader.Read(); // Advance past the end of the element.
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
