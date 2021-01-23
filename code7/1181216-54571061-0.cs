    public class DynamicAttributes : IXmlSerializable, IDictionary<string, object>
    {
        private readonly Dictionary<string, object> _attributes;
        public DynamicAttributes()
        {
            _attributes = new Dictionary<string, object>();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            if (reader.HasAttributes)
            {
                while (reader.MoveToNextAttribute())
                {
                    var key = reader.LocalName;
                    var value = reader.Value;
                    _attributes.Add(key, value);
                }
                // back to the owner of attributes
                reader.MoveToElement();
            }
            reader.ReadStartElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach (var attribute in _attributes)
            {
                writer.WriteStartAttribute(attribute.Key);
                writer.WriteValue(attribute.Value);
                writer.WriteEndAttribute();
            }
        }
        // implementation of IDictionary<string, object> comes here
    }
