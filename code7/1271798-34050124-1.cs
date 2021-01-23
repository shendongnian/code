                using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                {
                    rijndaelManaged.Padding = paddingMode;
                    rijndaelManaged.Key     = key;
                    rijndaelManaged.IV      = initVector;
    
                    MemoryStream memoryStream = null;
                    try
                    {
                        memoryStream = new MemoryStream(valueToDecrypt);
                        using (ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                            {
                                using (StreamReader streamReader = new StreamReader(cryptoStream))
                                {
                                    return streamReader.ReadToEnd();                       
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (memoryStream != null)
                            memoryStream.Dispose();
                    }
                }    
