    public static class XmlSerializerHelper
    {
        public static T LoadFromXML<T>(this string xmlString, XmlSerializer serial = null)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                object result = (serial ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
    }
    public static class DataContractJsonSerializerHelper
    {
        public static string GetJson<T>(T obj, DataContractJsonSerializer serializer = null)
        {
            using (var memory = new MemoryStream())
            {
                (serializer ?? new DataContractJsonSerializer(typeof(T))).WriteObject(memory, obj);
                memory.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(memory))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
