    public object DeserializeFromXmlString(Type targetType, string xmlString)
    {
        var serializer = new XmlSerializer(targetType);
        using (TextReader reader = new StringReader(xmlString))
        {
            return serializer.Deserialize(reader);
        }
    }
    
    public T DeserializeFromXmlString<T>(string xmlString)
    {
        return (T)DeserializeFromXmlString(typeof(T), xmlString);
    }
