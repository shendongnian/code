    public class Document : IXmlSerializable
    {
        public string DocumentPath { get; set; }
        public string DocumentTitle
        {
            get
            {
                if (DocumentPath == null)
                    return null;
                return Path.GetFileName(DocumentPath);
            }
        }
        const string DocumentTitleName = "DocumentTitle";
        const string BinaryDocumentName = "BinaryDocument";
        #region IXmlSerializable Members
        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void ReadXmlElement(XmlReader reader)
        {
            if (reader.Name == DocumentTitleName)
                DocumentPath = reader.ReadElementContentAsString();
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadXml(null, ReadXmlElement);
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteElementString(DocumentTitleName, DocumentTitle ?? "");
            if (DocumentPath != null)
            {
                try
                {
                    writer.WriteStartElement(BinaryDocumentName);
                    try
                    {
                        var buffer = new byte[6 * 1024];
                        using (var stream = File.OpenRead(DocumentPath))
                        {
                            int read;
                            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                                writer.WriteBase64(buffer, 0, read);
                        }
                    }
                    finally
                    {
                        writer.WriteEndElement();
                    }
                }
                catch (Exception ex)
                {
                    // You could log the exception as an element or as a comment, as you prefer.
                    // Log as a comment
                    writer.WriteComment("Caught exception with message: " + ex.Message);
                    writer.WriteComment("Exception details:");
                    writer.WriteComment(ex.ToString());
                    // Log as an element.
                    writer.WriteElementString("ExceptionMessage", ex.Message);
                    writer.WriteElementString("ExceptionDetails", ex.ToString());
                }
            }
        }
        #endregion
    }
    // test class
    public class DocumentContainer
    {
        public List<Document> DocumentCollection { get; set; }
    }
    public static class XmlSerializationExtensions
    {
        public static void ReadXml(this XmlReader reader, Action<IList<XAttribute>> readXmlAttributes, Action<XmlReader> readXmlElement)
        {
            if (reader.NodeType != XmlNodeType.Element)
                throw new InvalidOperationException("reader.NodeType != XmlNodeType.Element");
            if (readXmlAttributes != null)
            {
                var attributes = new List<XAttribute>(reader.AttributeCount);
                while (reader.MoveToNextAttribute())
                {
                    attributes.Add(new XAttribute(XName.Get(reader.Name, reader.NamespaceURI), reader.Value));
                }
                // Move the reader back to the element node.
                reader.MoveToElement();
                readXmlAttributes(attributes);
            }
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
                else
                {
                    using (var subReader = reader.ReadSubtree())
                    {
                        while (subReader.NodeType != XmlNodeType.Element) // Read past XmlNodeType.None
                            if (!subReader.Read())
                                break;
                        if (readXmlElement != null)
                            readXmlElement(subReader);
                    }
                    reader.Read();
                }
            }
            // Move past the end of the wrapper element
            reader.ReadEndElement();
        }
    }
