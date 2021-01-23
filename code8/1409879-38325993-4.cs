    for (int i = 0; i< 10; i++)
    {
        Debug.WriteLine(ByteArrayToHex((GetHash("a"))));
    }
    
    public static byte[] GetHash(string data)
    {
        IHashAlgorithmProvider algoProv = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
        byte[] dataTB = Encoding.UTF8.GetBytes(data);
        return algoProv.HashData(dataTB);
    }
    
    //Convert hash to hex
    private static string ByteArrayToHex(byte[] hash)
    {
        var hex = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            hex.AppendFormat("{0:x2}", b);
    
        return hex.ToString();
    }
