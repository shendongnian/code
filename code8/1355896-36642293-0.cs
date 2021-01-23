    byte[] MyBytes;
    BinaryFormatter bf = new BinaryFormatter();
    using (MemoryStream ms = new MemoryStream())
    {
        bf.Serialize(ms, obj);
        MyBytes = ms.ToArray();
    }
