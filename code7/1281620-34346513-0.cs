        public static XElement XmlSerialize(object obj, bool returnNullOnError = false)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                StringWriter stream = new StringWriter();
                serializer.Serialize(stream, obj);
				
                XDocument xml = XDocument.Parse(stream.ToString());
                return xml.Root;
            }
            catch
            {
                if (returnNullOnError)
                    return null;
                throw;
            }
        }
		
        public static object DeSerialize(XElement xmlSerialized, Type objectType)
        {
            XmlSerializer serializer = new XmlSerializer(objectType);
            XDocument d = new XDocument(xmlSerialized);
            object obj = null;
            using (XmlReader r = d.CreateReader())
            {
                obj = serializer.Deserialize(r);
            }
            return obj;
        }
