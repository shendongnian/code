    public T Deserialize(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T) serializer.Deserialize(new StringReader(xml));
    }
