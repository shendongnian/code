    public static string Decrypt(String strMsg)
    {
        Byte[] bb = Convert.FromBase64String(strMsg);
        IBuffer buffEncrypt = CryptographicEngine.Decrypt(Key, bb.AsBuffer(), IV.AsBuffer());
        return CryptographicBuffer.ConvertBinaryToString(encoding, buffEncrypt);
    }
