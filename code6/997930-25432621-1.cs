        public XmlDocument GetEntryXmlDoc(byte[] Bytes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                xmlDoc.Load(ms);
            }
            return xmlDoc;
        }
