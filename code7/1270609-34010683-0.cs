        public static class XmlReaderExtensions
        {
            public static void WalkXmlNodes(this XmlReader xmlReader, Action<XmlReader, Stack<XName>, IXmlLineInfo> action)
            {
                IXmlLineInfo xmlInfo = xmlReader as IXmlLineInfo;
                try
                {
                    Stack<XName> names = new Stack<XName>();
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            names.Push(XName.Get(xmlReader.Name, xmlReader.NamespaceURI));
                        }
                        action(xmlReader, names, xmlInfo);
                        if ((xmlReader.NodeType == XmlNodeType.Element && xmlReader.IsEmptyElement)
                            || xmlReader.NodeType == XmlNodeType.EndElement)
                        {
                            names.Pop();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Rethrow exception with line number information.
                    var line = (xmlInfo == null ? -1 : xmlInfo.LineNumber);
                    var pos = (xmlInfo == null ? -1 : xmlInfo.LinePosition);
                    var exception = new XmlException("XmlException occurred", ex, line, pos);
                    throw ex;
                }
            }
        }
