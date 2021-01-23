    var text = "Hello World";
    var buffer = Encoding.UTF8.GetBytes(text);
    
    var iv = GetRandomData(128);
    var keyAes = GetRandomData(256);
    
    
    byte[] result;
    using (var aes = Aes.Create())
    {
        aes.Key = keyAes;
        aes.IV = iv;
    
        using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
        using (var resultStream = new MemoryStream())
        {
            using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
            using (var plainStream = new MemoryStream(buffer))
            {
                plainStream.CopyTo(aesStream);
            }
    
            result = resultStream.ToArray();
        }
    }
        
