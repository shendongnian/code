    byte[] data = null;
    
    using (MemoryStream ms = new MemoryStream())
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(ms, obj);
        data =  ms.ToArray();
    }
                
    using (MemoryStream ms = new MemoryStream(data))
    {
        BinaryFormatter binaryFormatter2 = new BinaryFormatter();
        var objDeserialized = binaryFormatter2.Deserialize(ms) as someType;
    }
