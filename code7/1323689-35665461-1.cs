    public class PersonElement : ConfigurationElement
    {
        public string InnerText { get; private set; }
    
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
        {
            InnerText = reader.ReadElementContentAsString();
        }
    }
