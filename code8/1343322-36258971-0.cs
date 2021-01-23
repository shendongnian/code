    public byte[] ObjectToBytes(Object obj)
    {
        try
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memStream, obj);
    
                return memStream.ToArray();
            }
        }
        catch (Exception) { }  // do what you want
    
        return null;
    }
    
    public T BytesToObject<T>(byte[] array) where T : class
    {
        try
        {
            using (MemoryStream memStream = new MemoryStream(array) { Position = 0 })
            {
                BinaryFormatter formatter = new BinaryFormatter();
                T obj = formatter.Deserialize(memStream) as T;
    
                return obj;
            }
        }
        catch (Exception) { }  // do what you want
    
        return null;
    }
