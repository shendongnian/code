        private static string GetXmlEncoding(string xmlString)
        {
            using (StringReader stringReader = new StringReader(xmlString))
            {
                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                var reader = XmlReader.Create(stringReader, settings);
                reader.Read();
                var result = reader.GetAttribute("encoding");
                return result;
            }
        }
