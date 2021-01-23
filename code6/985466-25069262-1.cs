    public static T Deserialize<T>(this byte[] source)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        return (T) serializer.Deserialize(new MemoryStream(source));
    }
