    public class XmlValueAndAttribute : IXmlSerializable
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string Value { get; set; }
        public XmlValueAndAttribute() { }
        public XmlValueAndAttribute(string value, string attribute, string attributeName)
        {
            Value = value;
            AttributeValue = attribute;
            AttributeName = attributeName;
        }
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }
        static XName nilName = XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance");
        public void ReadXml(XmlReader reader)
        {
            using (var subReader = reader.ReadSubtree())
            {
                var element = XElement.Load(subReader);
                reader.Read(); // Advance past the end of the element.
                if (element == null)
                    return;
                Value = (bool?)element.Attribute(nilName) == true ? null : element.Value;
                var attr = element.Attributes().Where(a => a.Name != nilName && !a.IsNamespaceDeclaration).FirstOrDefault();
                if (attr != null)
                {
                    AttributeName = XmlConvert.DecodeName(attr.Name.LocalName);
                    AttributeValue = attr.Value;
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            if (!string.IsNullOrEmpty(AttributeName))
                writer.WriteAttributeString(XmlConvert.EncodeLocalName(AttributeName), AttributeValue);
            if (Value == null)
                writer.WriteAttributeString("xsi", nilName.LocalName, nilName.Namespace.ToString(), XmlConvert.ToString(true));
            else
                writer.WriteString(Value);
        }
        #endregion
    }
