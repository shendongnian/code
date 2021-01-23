        public void WriteToXml(TextWriter writer)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true, IndentChars = "\t" };
            string xml;
            using (var tempWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(tempWriter, settings))
                    new XmlSerializer(this.GetType()).Serialize(xmlWriter, this, ns);
                xml = tempWriter.ToString();
            }
            using (var reader = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(reader))
            {
                XmlNodeType? prevType = null;
                using (var xmlWriter = XmlWriter.Create(writer, settings))
                {
                    while (xmlReader.Read())
                    {
                        if ((xmlReader.NodeType == XmlNodeType.Element || xmlReader.NodeType == XmlNodeType.EndElement)
                             && (prevType == null || prevType == XmlNodeType.Whitespace))
                        {
                            xmlWriter.WriteWhitespace(settings.IndentChars); // Add one more indentation
                        }
                        xmlWriter.WriteShallowNode(xmlReader);
                        prevType = xmlReader.NodeType;
                    }
                }
            }
        }
