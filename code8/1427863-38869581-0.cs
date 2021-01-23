    public Packet(List<byte> data)
    {
        using (Stream stream = new MemoryStream())
        {
            // Loop list and write out bytes
            foreach(byte b in data)
                stream.WriteByte(b);
    
            // Reset stream position ready for read
            stream.Seek(0, SeekOrigin.Begin);
    
            using (BinaryReader reader = new BinaryReader(stream))
            {
                Length = reader.ReadInt16();
                pID = reader.ReadByte();
                Result = reader.ReadByte();
                Message = reader.ReadString();
                ID = reader.ReadInt32();
            }
        }
    }
