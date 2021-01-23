    public static class SerializationExtensions
    {
        public static string ToXml<T>(this List<T> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>)); 
     
            StringWriter stringWriter = new StringWriter(); 
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter); 
     
            xmlWriter.Formatting = Formatting.Indented; 
            xmlSerializer.Serialize(xmlWriter, list); 
     
            return stringWriter.ToString();     
        }
    }
