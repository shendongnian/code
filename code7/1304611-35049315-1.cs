    public static byte[] HexToByteArray(string hexstring)
    {
        var bytes = new List<byte>();
        for (int i = 0; i < hexstring.Length/2; i++)
            bytes.Add(Convert.ToByte("" + hexstring[i*2] + hexstring[i*2 + 1], 16));
        return bytes.ToArray();
    }
