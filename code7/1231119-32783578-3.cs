    using (BinaryWriter writer = new BinaryWriter(sWriter, Encoding.UTF8))
    {
        var bytes = new List<byte>();
        var floatValue = 23.4F;
        var ip = "192.168.111"
        var stringBytes = Encoding.ASCII.GetBytes(string);
        bytes.Add(0x03) // type of message: string
        bytes.Add(BitConverter.GetBytes(stringBytes.Length)); // 8 bytes with length
        bytes.AddRange(stringBytes); // entire string
        writer.Write(bytes.ToArray());
    }
