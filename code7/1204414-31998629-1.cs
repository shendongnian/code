    public Stream encryptStream(Stream input)
    {
        var output = new MemoryStream();
        using (var alg = new RijndaelManaged { Padding = PaddingMode.PKCS7 })
        {
            var key = HashStringMD5(DefaultKey);
            alg.KeySize = key.Length * 8;
            alg.Key = key;
            alg.IV = key;
            byte[] encryptedCopy;
            using (var enc = alg.CreateEncryptor())
            {
                var crypt = new CryptoStream(output, enc, CryptoStreamMode.Write);
                input.CopyTo(crypt);
                crypt.FlushFinalBlock();
                encryptedCopy = output.ToArray();
            }
            var inputCopy = new byte[input.Length];
            input.Position = 0;
            input.Read(inputCopy, 0, inputCopy.Length);
            using (var test = new MemoryStream())
            using (var dec = alg.CreateDecryptor())
            using (var crypt = new CryptoStream(test, dec, CryptoStreamMode.Write))
            {
                crypt.Write(encryptedCopy, 0, encryptedCopy.Length);
                crypt.FlushFinalBlock();
                var decryptionTest = test.ToArray();
                if (decryptionTest.Length != inputCopy.Length || decryptionTest.Where((t, i) => t != inputCopy[i]).Any())
                {
                    throw new InvalidOperationException("not orthogonal");
                }
            }
        }
        input.Position = 0;
        output.Position = 0;
        return output;
    }
