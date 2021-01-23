    public static T DeserializeFromString<T>(String xml) where T : class
        {
            try
            {
                var xDoc = XDocument.Parse(xml);
                using (var xmlReader = xDoc.Root.CreateReader())
                {
                    return new XmlSerializer(typeof(T)).Deserialize(xmlReader) as T;
                }
            }
            catch ()
            {
                return default(T);
            }
        }
