    public T Deserialize<T>(T obj, string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        obj = (T)serializer.Deserialize(reader);
        reader.Close();
        return obj;
    }
