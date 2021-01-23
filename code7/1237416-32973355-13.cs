     public string ToXML<T>(T obj)
     {
        using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
        }
     }
