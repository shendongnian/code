    public static void WriteStringToFile(string fileName, string plainText, byte[] key, byte[] iv)
    {
        using (Rijndael algo = Rijndael.Create())
        {
            algo.Key = key;
            algo.IV = iv;
            algo.Mode = CipherMode.CBC;
            algo.Padding = PaddingMode.PKCS7;
            // Create the streams used for encryption.
            using (FileStream file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            // Create an encryptor to perform the stream transform.
            using (ICryptoTransform encryptor = algo.CreateEncryptor())
            using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
            using (StreamWriter sw = new StreamWriter(cs))
            {
                // Write all data to the stream.
                sw.Write(plainText);
            }
        }
    }
    public static void AppendStringToFile(string fileName, string plainText, byte[] key, byte[] iv)
    {
        using (Rijndael algo = Rijndael.Create())
        {
            algo.Key = key;
            // The IV is set below
            algo.Mode = CipherMode.CBC;
            algo.Padding = PaddingMode.PKCS7;
            // Create the streams used for encryption.
            using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] previous = null;
                int previousLength = 0;
                long length = file.Length;
                // No check is done that the file is correct!
                if (length != 0)
                {
                    // The IV length is equal to the block length
                    byte[] block = new byte[iv.Length];
                    if (length >= iv.Length * 2)
                    {
                        // At least 2 blocks, take the penultimate block
                        // as the IV
                        file.Position = length - iv.Length * 2;
                        file.Read(block, 0, block.Length);
                        algo.IV = block;
                    }
                    else
                    {
                        // A single block present, use the IV given
                        file.Position = length - iv.Length;
                        algo.IV = iv;
                    }
                    // Read the last block
                    file.Read(block, 0, block.Length);
                    // And reposition at the beginning of the last block
                    file.Position = length - iv.Length;
                    // We use a MemoryStream because the CryptoStream
                    // will close the Stream at the end
                    using (var ms = new MemoryStream(block))
                    // Create a decrytor to perform the stream transform.
                    using (ICryptoTransform decryptor = algo.CreateDecryptor())
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read all data from the stream. The decrypted last
                        // block can be long up to block length characters
                        // (so up to iv.Length) (this with AES + CBC)
                        previous = new byte[iv.Length];
                        previousLength = cs.Read(previous, 0, previous.Length);
                    }
                }
                else
                {
                    // Use the IV given
                    algo.IV = iv;
                }
                // Create an encryptor to perform the stream transform.
                using (ICryptoTransform encryptor = algo.CreateEncryptor())
                using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    // Rewrite the last block, if present. We even skip
                    // the case of block present but empty
                    if (previousLength != 0)
                    {
                        cs.Write(previous, 0, previousLength);
                    }
                    // Write all data to the stream.
                    sw.Write(plainText);
                }
            }
        }
    }
    public static string ReadStringFromFile(string fileName, byte[] key, byte[] iv)
    {
        string plainText;
        using (Rijndael algo = Rijndael.Create())
        {
            algo.Key = key;
            algo.IV = iv;
            algo.Mode = CipherMode.CBC;
            algo.Padding = PaddingMode.PKCS7;
            // Create the streams used for decryption.
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            // Create a decrytor to perform the stream transform.
            using (ICryptoTransform decryptor = algo.CreateDecryptor())
            using (CryptoStream cs = new CryptoStream(file, decryptor, CryptoStreamMode.Read))
            using (StreamReader sr = new StreamReader(cs))
            {
                // Read all data from the stream.
                plainText = sr.ReadToEnd();
            }
        }
        return plainText;
    }
