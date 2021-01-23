    public static byte[] EncodePrintableString(string data)
        {
            var dataBytes = Encoding.ASCII.GetBytes(data);
            return getDerBytes(0x13, dataBytes);
        }
