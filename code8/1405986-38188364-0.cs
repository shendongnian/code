    using (var des = new AesCryptoServiceProvider())
    {
        byte[] result;
    
        using (var ms = new MemoryStream())
        {
            using (var encryptor = des.CreateEncryptor())
            using (var cryptS = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var defS = new DeflateStream(cryptS, CompressionMode.Compress))
            using (var bw = new BinaryWriter(defS))
            {
                bw.Write("Hello, World.");
            }
    
            result = ms.ToArray();
        }            
    
        using (var ms = new MemoryStream(result))            
        using (var decryptor = des.CreateDecryptor())
        using (var cryptS2 = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
        using (var defS = new DeflateStream(cryptS2, CompressionMode.Decompress))
        using (var br = new BinaryReader(defS))
        {
            var x = br.ReadString();
        }
    }
