            XmlReader xmlReader = XmlReader.Create(networkStream);
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlReadBuffer = XmlWriter.Create(stringWriter);
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        xmlReadBuffer.WriteStartDocument();
                        break;
                    case XmlNodeType.Element:
                        xmlReadBuffer.WriteStartElement(xmlReader.Name);
                        if (xmlReader.HasAttributes)
                            xmlReadBuffer.WriteAttributes(xmlReader, false);
                        if (xmlReader.IsEmptyElement)
                            goto case XmlNodeType.EndElement;
                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Depth == 0)
                        {
                            xmlReadBuffer.WriteEndElement();
                            xmlReadBuffer.WriteEndDocument();
                            goto EndXml;
                        }
                        xmlReadBuffer.WriteEndElement();
                        break;
                    case XmlNodeType.Text:
                        xmlReadBuffer.WriteString(xmlReader.Value);
                        break;
                    default:
                        break;
                }
            }
        EndXml:
        xmlReadBuffer.Flush();
        XPathDocument xPathDocument = new XPathDocument(XmlReader.Create(new StringReader(stringWriter.ToString())));
