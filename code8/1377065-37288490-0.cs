    byte[] GetMasterServerQueryDatagram(byte regionCode, string address, string filter)
    {
        MemoryStream stream = new MemoryStream();
        stream.WriteByte(0x31);
        stream.WriteByte(regionCode);
        byte[] stringZero = Encoding.ASCII.GetBytes(address + "\0");
        stream.Write(stringZero, 0, stringZero.Length);
        stringZero = Encoding.ASCII.GetBytes(filter + "\0");
        stream.Write(stringZero, 0, stringZero.Length);
        return stream.ToArray();
    }
