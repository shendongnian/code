    using (var memoryStream = new MemoryStream())
    {
        using (var transform = algorithm.CreateEncryptor())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(source, 0, source.Length);
                // Tell the CryptoStream we've written all the data and padding should be applied
                cryptoStream.FlushFinalBlock();
            }
        }
        output = memoryStream.ToArray();
    }
