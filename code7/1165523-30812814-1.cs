    public static class XmlSerializationHelper
    {
        public static T LoadFromXML<T>(this string xmlString)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = new XmlSerializer(typeof(T)).Deserialize(reader);
                if (result is T)
                {
                    return (T)result;
                }
            }
            return default(T);
        }
        public static T LoadFromFile<T>(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open))
            {
                object result =  new XmlSerializer(typeof(T)).Deserialize(fs);
                if (result is T)
                {
                    return (T)result;
                }
            }
            return default(T);
        }
    }
