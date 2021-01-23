    public void Serialize(Dictionary<int, UserSessionInfo> dictionary, Stream stream)
    {
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(dictionary.Count);
        foreach (var obj in dictionary)
        {
            writer.Write(obj.Key);
            writer.Write(obj.Value);
        }
        writer.Flush();
    }
    
    public Dictionary<int, UserSessionInfo> Deserialize(Stream stream)
    {
        BinaryReader reader = new BinaryReader(stream);
        int count = reader.ReadInt32();
        var dictionary = new Dictionary<int, UserSessionInfo>(count);
        for (int n = 0; n < count; n++)
        {
            var key = reader.ReadInt32();
            var value = reader.ReadString();
            dictionary.Add(key, value);
        }
        return dictionary;                
    }
