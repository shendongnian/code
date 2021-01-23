          public static string Serialise<T>(T serialisableObject)
          {
            var doc = new XmlDocument();
            using (var stream = new StringWriter())
            {
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                XmlWriter xmlWriter = XmlWriter.Create(stream, settings);
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(xmlWriter, serialisableObject, ns);
                doc.LoadXml(stream.ToString());
            }
            return doc.InnerXml;
        }
        public static T Deserialise<T>(string xml)
        {
            T list;
            using (var reader = new StringReader(xml))
            {
                var serialiser = new XmlSerializer(typeof(T));
                list = (T)serialiser.Deserialize(reader);
            }
            return list;
        }
