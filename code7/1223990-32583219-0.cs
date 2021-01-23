    [Serializable]
    public struct XmlDocumentSerializationWrapper : ISerializable
    {
        public static implicit operator XmlDocumentSerializationWrapper(XmlDocument data) { return new XmlDocumentSerializationWrapper(data); }
        public static implicit operator XmlDocument(XmlDocumentSerializationWrapper proxy) { return proxy.XmlDocument; }
        private readonly XmlDocument xmlDocument;
        public XmlDocument XmlDocument { get { return xmlDocument; } }
        public XmlDocumentSerializationWrapper(XmlDocument xmlDocument)
        {
            this.xmlDocument = xmlDocument;
        }
        public XmlDocumentSerializationWrapper(SerializationInfo info, StreamingContext context)
        {
            var xml = (string)info.GetValue("XmlDocument", typeof(string));
            if (!string.IsNullOrEmpty(xml))
            {
                xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
            }
            else
            {
                xmlDocument = null;
            }
        }
        #region ISerializable Members
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (XmlDocument != null)
            {
                var xml = XmlDocument.OuterXml;
                info.AddValue("XmlDocument", xml);
            }
            else
            {
                info.AddValue("XmlDocument", (string)null);
            }
        }
        #endregion
    }
