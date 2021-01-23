    public static string DecryptString(string code)
        {
            byte[] text = FromHex("0102030405060708090a0b0c0d0e0f11");
            byte[] key = FromHex("ed7c0c82daf513b81c32f6655e8fd4ee");
            //Expected result: 260fe45846fb26dbb1d28d8166d4a89f
            return BitConverter.ToString(Encoding.Default.GetBytes(decrypt(text, key)));
        }
        public static byte[] FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        } 
        
        public static String decrypt(byte[] input, byte[] key)
        {
            byte[] data = input;
            String decrypted;
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.Mode = CipherMode.ECB;
                rijAlg.BlockSize = 128;
                rijAlg.Padding = PaddingMode.Zeros;
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, null);
                using (MemoryStream msDecrypt = new MemoryStream(data))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return decrypted;
        }
