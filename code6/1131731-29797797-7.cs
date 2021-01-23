        // method used to deserialize an xml to object
        public static T Deserialize<T>(string xmlContent)
        {
            T result;
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StringReader(xmlContent))
            {
                result = ((T)xmlSerializer.Deserialize(textReader));
            }
            return result;
        }
