    using (BinaryWriter writer = new BinaryWriter(sWriter, Encoding.UTF8))
    {
        var floatValue = 23.4F;
        var bytes = new List<byte>();
        bytes.Add(0x03) // type of message: float
        bytes.Add(BitConverter.GetBytes(floatValue)); // 4 bytes of float
        writer.Write(bytes.ToArray());
    }
