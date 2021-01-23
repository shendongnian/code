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
            {
                // Create an encryptor to perform the stream transform.
                using (ICryptoTransform encryptor = algo.CreateEncryptor())
                {
                    using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Write all data to the stream.
                            sw.Write(plainText);
                        }
                    }
                }
            }
        }
    }
    public static void AppendStringToFile(string fileName, string plainText, byte[] key, byte[] iv)
    {
        using (Rijndael algo = Rijndael.Create())
        {
            algo.Key = key;
            algo.IV = iv;
            algo.Mode = CipherMode.CBC;
            algo.Padding = PaddingMode.PKCS7;
            // Create the streams used for encryption.
            using (FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                long length = file.Length;
                string previous = null;
                // No check is done that the file is correct!
                if (length != 0)
                {
                    // The IV length is equal to the block length
                    byte[] block = new byte[iv.Length];
                    // At least 2 blocks, take from the penultimate block
                    // the IV
                    if (length >= iv.Length * 2)
                    {
                        file.Position = length - iv.Length * 2;
                        file.Read(block, 0, block.Length);
                        algo.IV = block;
                    }
                    else
                    {
                        // A single block present, use the IV given
                        file.Position = length - iv.Length;
                    }
                    // Create a decrytor to perform the stream transform.
                    using (ICryptoTransform decryptor = algo.CreateDecryptor())
                    {
                        file.Read(block, 0, block.Length);
                        // We use a MemoryStream because the CryptoStream
                        // will close the Stream at the end!
                        using (var ms = new MemoryStream(block))
                        {
                            // Create a decrytor to perform the stream transform.
                            using (ICryptoTransform decryptor = algo.CreateDecryptor())
                            {
                                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                                {
                                    using (StreamReader sr = new StreamReader(cs))
                                    {
                                        // Read all data from the stream.
                                        previous = sr.ReadToEnd();
                                    }
                                }
                            }
                        }
                    }
                    file.Position = length - iv.Length;
                }
                // Create an encryptor to perform the stream transform.
                using (ICryptoTransform encryptor = algo.CreateEncryptor())
                {
                    using (CryptoStream cs = new CryptoStream(file, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Rewrite the last block, if present
                            if (previous != null)
                            {
                                sw.Write(previous);
                            }
                            // Write all data to the stream.
                            sw.Write(plainText);
                        }
                    }
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
            {
                // Create a decrytor to perform the stream transform.
                using (ICryptoTransform decryptor = algo.CreateDecryptor())
                {
                    using (CryptoStream cs = new CryptoStream(file, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            // Read all data from the stream.
                            plainText = sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        return plainText;
    }
