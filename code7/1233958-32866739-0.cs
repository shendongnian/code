    public byte CalcCRC(byte start, byte[] buffer)
    {
        unchecked
        {
            byte crc = start;
            for (int i = 0; i < buffer.Length; i++)
                crc += buffer[i];
            return (byte)(0 - crc);
        }
    }
