    public class XmlSerializableList<T> : List<T>, IXmlSerializable where T : new()
    {
        public XmlSerializableList() : base() { }
        public XmlSerializableList(IEnumerable<T> collection) : base(collection) { }
        public XmlSerializableList(int capacity) : base(capacity) { }
        #region IXmlSerializable Members
        const string CollectionItemsName = "Items";
        const string CollectionPropertiesName = "Properties";
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            // Do not write the wrapper element.
            // Serialize the collection.
            WriteCollectionElements(writer);
            // Serialize custom properties.
            writer.WriteStartElement(CollectionPropertiesName);
            WriteCustomElements(writer);
            writer.WriteEndElement();
            // Do not end the wrapper element.
        }
        private void WriteCollectionElements(XmlWriter writer)
        {
            if (Count < 1)
                return;
            // Serialize the collection.
            writer.WriteStartElement(CollectionItemsName);
            var serializer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            foreach (var item in this)
            {
                serializer.Serialize(writer, item, ns);
            }
            writer.WriteEndElement();
        }
        /// <summary>
        /// Write ALL custom elements to the XmlReader
        /// </summary>
        /// <param name="writer"></param>
        protected virtual void WriteCustomElements(XmlWriter writer)
        {
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            reader.ReadStartElement(); // Advance to the first sub element of the wrapper element.
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType != XmlNodeType.Element)
                    // Comment, whitespace
                    reader.Read();
                else if (reader.IsEmptyElement)
                    reader.Read();
                else if (reader.Name == CollectionItemsName)
                    ReadCollectionElements(reader);
                else if (reader.Name == CollectionPropertiesName)
                    ReadCustomElements(reader);
                else
                    // Unknown element, skip it.
                    reader.Skip();
            }
            // Move past the end of the wrapper element
            reader.ReadEndElement();
        }
        void ReadCustomElements(XmlReader reader)
        {
            reader.ReadStartElement(); // Advance to the first sub element of the collection element.
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    using (var subReader = reader.ReadSubtree())
                    {
                        while (subReader.NodeType != XmlNodeType.Element) // Read past XmlNodeType.None
                            if (!subReader.Read())
                                break;
                        ReadCustomElement(subReader);
                    }
                }
                reader.Read();
            }
            // Move past the end of the properties element
            reader.Read();
        }
        void ReadCollectionElements(XmlReader reader)
        {
            var serializer = new XmlSerializer(typeof(T));
            reader.ReadStartElement(); // Advance to the first sub element of the collection element.
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    using (var subReader = reader.ReadSubtree())
                    {
                        while (subReader.NodeType != XmlNodeType.Element) // Read past XmlNodeType.None
                            if (!subReader.Read())
                                break;
                        var item = (T)serializer.Deserialize(subReader);
                        Add(item);
                    }
                }
                reader.Read();
            }
            // Move past the end of the collection element
            reader.Read();
        }
        /// <summary>
        /// Read ONE custom element from the XmlReader
        /// </summary>
        /// <param name="reader"></param>
        protected virtual void ReadCustomElement(XmlReader reader)
        {
        }
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        #endregion
    }
