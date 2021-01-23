    public void StoreToFile<T>(T ObjectToStore, string FileName)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using(Stream str = File.Create(FileName))
            ser.Serialize(str, ObjectToStore);
    }
    public T RetrieveFromFile(string FileName)
    {
        XmlSerializer ser = new XmlSerializer(typeof(T));
        using(Stream str = File.Open(FileName))
            return (T)ser.Deserialize(str);
    }
