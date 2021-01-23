    public void Save(string path)
    {
        string json = MiniJSON.Json.Serialize(m_saveData);
        using (RijndaelManaged crypto = new RijndaelManaged())
        {
            crypto.BlockSize = KEY_SIZE;
            crypto.Padding = PaddingMode.PKCS7;
            crypto.Key = m_cryptoKey;
            crypto.IV = m_cryptoIV;
            crypto.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);
            byte[] compressed = null;
            using (MemoryStream compMemStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(compMemStream, Encoding.UTF8))
                {
                    writer.Write(json);
                    writer.Close();
                    //compressed = CLZF2.Compress(compMemStream.ToArray());
                    compressed = compMemStream.ToArray();
                }
            }
            if (compressed != null)
            {
                using (MemoryStream encMemStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(encMemStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(compressed, 0, compressed.Length);
                        cryptoStream.FlushFinalBlock();
                        using (FileStream fs = File.Create(GetSavePath(path)))
                        {
                            encMemStream.WriteTo(fs);
                        }
                    }
                }
            }
        }
    }
    public void Load(string path)
    {
        path = GetSavePath(path);
        try
        {
            byte[] decrypted = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (RijndaelManaged crypto = new RijndaelManaged())
                {
                    crypto.BlockSize = KEY_SIZE;
                    crypto.Padding = PaddingMode.PKCS7;
                    crypto.Key = m_cryptoKey;
                    crypto.IV = m_cryptoIV;
                    crypto.Mode = CipherMode.CBC;
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream decMemStream = new MemoryStream())
                        {
                            var buffer = new byte[512];
                            var bytesRead = 0;
                            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                decMemStream.Write(buffer, 0, bytesRead);
                            }
                            //decrypted = CLZF2.Decompress(decMemStream.ToArray());
                            decrypted = decMemStream.ToArray();
                        }
                    }
                }
            }
            if (decrypted != null)
            {
                using (MemoryStream jsonMemoryStream = new MemoryStream(decrypted))
                {
                    using (StreamReader reader = new StreamReader(jsonMemoryStream))
                    {
                        string json = reader.ReadToEnd();
                        Dictionary<string, object> saveData = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
                        if (saveData != null)
                        {
                            m_saveData = saveData;
                        }
                        else
                        {
                            Debug.LogWarning("Trying to load invalid JSON file at path: " + path);
                        }
                    }
                }
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogWarning("No save file found at path: " + path);
        }
    }
