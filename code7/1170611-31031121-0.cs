    public Stream GetResults()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        formatter.Serialize(stream, GetItemsFromTable1());
        formatter.Serialize(stream, GetItemsFromTable2());
        formatter.Serialize(stream, GetItemsFromTable3());
        formatter.Serialize(stream, GetItemsFromTable4());
        stream.Seek(0L, SeekOrigin.Begin);
        return stream;
    }
