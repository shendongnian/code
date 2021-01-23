    using (NetworkStream netStream = new NetworkStream(...))
    using (BinaryReader br = new BinaryReader(netStream))
    {
        byte x;
        do
        {
            try
            {
                x = br.ReadByte();
            }
            catch (EndOfStreamException exception)
            {
                x = Byte.MinValue;
            }
        } while (x != byte.MinValue);
    }
