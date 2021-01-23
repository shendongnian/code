    private byte[] HexMD5(string text)
    {
        var md5 = new MD5Digest();
    
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        byte[] result = new byte[md5.GetDigestSize()];
    
        md5.BlockUpdate(bytes, 0, bytes.Length);
        md5.DoFinal(result, 0);
    
        return result;
    }
