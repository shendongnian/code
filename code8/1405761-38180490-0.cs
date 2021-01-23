    int a = 566;
    int b = 1106;
    int c = 649;
    int d = 299;
    // Writing.
    byte[] data = new byte[sizeof(int) * 4];
    using (MemoryStream stream = new MemoryStream(data))
    using (BinaryWriter writer = new BinaryWriter(stream))
    {
        writer.Write(a);
        writer.Write(b);
        writer.Write(c);
        writer.Write(d);
    }
    // Reading.
    using (MemoryStream stream = new MemoryStream(data))
    using (BinaryReader reader = new BinaryReader(stream))
    {
        a = reader.ReadInt32();
        b = reader.ReadInt32();
        c = reader.ReadInt32();
        d = reader.ReadInt32();
    }
    // Check results.
    Trace.Assert(a == 566);
    Trace.Assert(b == 1106);
    Trace.Assert(c == 649);
    Trace.Assert(d == 299);
