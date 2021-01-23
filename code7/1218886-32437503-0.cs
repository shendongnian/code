        // De-Serializes the request into class object
        public T DeserializeXml<T>(XmlNode xmlToDesearialized)
        {
            if (xmlToDesearialized == null) throw new ArgumentNullException("xmlToDesearialized");
            T deserializedObject = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader stringReader = new StringReader(xmlToDesearialized.OuterXml))
            {
                XmlTextReader xmlTextReader = new XmlTextReader(stringReader);
                deserializedObject = (T)xmlSerializer.Deserialize(xmlTextReader);
            }
            return deserializedObject;
        }
