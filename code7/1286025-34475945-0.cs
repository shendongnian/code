    List<byte> bits = new List<byte>();
    using(FileStream s = new FileStream(@"d:\temp\test1.txt", FileMode.Open))
    using (BinaryReader reader = new BinaryReader(s))
    {
        reader.BaseStream.Position = 0x1290;
        while (reader.PeekChar() != -1)
        {
            byte b = reader.ReadByte();
            if(b != 0x00)
                bits.Add(reader.ReadByte());
        }
        string result = Encoding.UTF8.GetString(bits.ToArray());
    }
