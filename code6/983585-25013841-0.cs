    public static string decrypt()
    {
        byte[] plainbytes = new byte[chiperbytes.Length];
        MemoryStream ms = new MemoryStream(chiperbytes);
        CryptoStream cs = new CryptoStream(ms, desObj.CreateDecryptor(), CryptoStreamMode.Read);
        cs.Read(plainbytes, 0, plainbytes.Length);
        cs.Close();
        ms.Close();
        return Encoding.ASCII.GetString(plainbytes).TrimEnd('\0');
    }
