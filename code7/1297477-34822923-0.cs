    public static class HtmlHelper
    {
        /// <summary>
        /// Keep only the openning and closing tag, and text content from the html
        /// </summary>
        public static string CleanUp(string html)
        {
            var output = new StringBuilder();
            using (var reader = XmlReader.Create(new StringReader(html)))
            {
                var settings = new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true };
                using (var writer = XmlWriter.Create(output, settings))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                writer.WriteStartElement(reader.Name);
                                break;
                            case XmlNodeType.Text:
                                writer.WriteString(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                writer.WriteFullEndElement();
                                break;
                        }
                    }
                }
            }
            
            return output.ToString();
        }
    }
