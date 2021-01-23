    public static void Serialize(Dictionary<int, object> dictionary, ref Stream stream)
    {
        stream = new MemoryStream();
        new BinaryFormatter().Serialize(stream, dictionary);
    }
    public static static Dictionary<int, object> Deserialize(Stream stream)
    {
        return (Dictionary<int, object>)new BinaryFormatter().Deserialize(stream);
    }
