    using (BinaryWriter writer = new BinaryWriter(file))
    {
        writer.Write(100000);
        writer.Write(5.0f);
        writer.Write(10.0f);
        writer.Write(15.0f);
        writer.Write(20.0f);
    }
