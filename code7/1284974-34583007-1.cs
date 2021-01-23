    var input = CryptographicBuffer.ConvertStringToBinary("d9e978bc7ca9179f0d51e91521d41d8d", BinaryStringEncoding.Utf8);
    var key = CryptographicBuffer.ConvertStringToBinary("12345678abcdefgh", BinaryStringEncoding.Utf8);
    var iv = CryptographicBuffer.ConvertStringToBinary("87654321hgfedcba", BinaryStringEncoding.Utf8);
    
    var encryptor = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbc);
    
    byte[] a = iv.ToArray();
    byte[] b = CryptographicEngine.Encrypt(encryptor.CreateSymmetricKey(key), input, iv).ToArray();
    
    byte[] c = new byte[a.Length + b.Length];
    Buffer.BlockCopy(a, 0, c, 0, a.Length);
    Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
    
    var result = Convert.ToBase64String(c);
