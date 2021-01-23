    [XmlRoot("PreviouslyVisitedPaths")]
    public class PreviouslySelectedPaths : OrderedDictionary, IXmlSerializable
    {
    
        #region Implementation of IXmlSerializable
    
        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            var keySerializer = new XmlSerializer(typeof(object));
            var valueSerializer = new XmlSerializer(typeof(object));
    
            var wasEmpty = reader.IsEmptyElement;
            reader.Read();
    
            if(wasEmpty)
            {
                return;
            }
    
            while(reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("item");
    
                reader.ReadStartElement("key");
                var key = keySerializer.Deserialize(reader);
                reader.ReadEndElement();
    
                reader.ReadStartElement("value");
                var value = valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
    
                Add(key, value);
    
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }
    
        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            var keySerializer = new XmlSerializer(typeof(object));
            var valueSerializer = new XmlSerializer(typeof(object));
    
            foreach(var key in Keys)
            {
                writer.WriteStartElement("item");
    
                writer.WriteStartElement("key");
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();
    
                writer.WriteStartElement("value");
                var value = this[key];
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();
    
                writer.WriteEndElement();
            }
    
            #endregion
        }
    }
