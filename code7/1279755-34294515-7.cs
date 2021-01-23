        private static Encoding GetXmlEncoding(string xmlString)
        {
            using (StringReader stringReader = new StringReader(xmlString))
            {
                var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
                var reader = XmlReader.Create(stringReader, settings);
                reader.Read();
                var encoding = reader.GetAttribute("encoding");
                var result = Encoding.GetEncoding(encoding);
                return result;
            }
        }
