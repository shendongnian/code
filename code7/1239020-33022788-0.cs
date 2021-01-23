    public byte[] ToByteArray<T>(T obj)
    {
        if(obj == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using(MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
    public T FromByteArray<T>(byte[] data)
    {
        if(data == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using(MemoryStream ms = new MemoryStream(data))
        {
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }
    }
