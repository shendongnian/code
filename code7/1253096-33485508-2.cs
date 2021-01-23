            public static String Decrypt(byte[] buff, byte[] key, byte[] iv)
            {
                using (System.Security.Cryptography.RijndaelManaged rijndael = new System.Security.Cryptography.RijndaelManaged())
                {
                    rijndael.Padding = PaddingMode.PKCS7;
                    rijndael.Mode = CipherMode.CBC;
                    rijndael.KeySize = 128;
                    rijndael.BlockSize = 128;
                    ICryptoTransform decryptor = rijndael.CreateDecryptor(key, iv);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(buff);
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    byte[] output = new byte[buff.Length];
                    int readBytes = cryptoStream.Read(output, 0, output.Length);
                    return System.Text.Encoding.UTF8.GetString(output, 0, readBytes);
                }
            }
