        public static string DecryptLikeSite(string base64EncodedCipherText, string key)
        {
            using (var alg = new RijndaelManaged())
            {
                alg.BlockSize = 256;
                alg.Key = System.Text.Encoding.ASCII.GetBytes(key).Take(32).ToArray();
                alg.Mode = CipherMode.ECB;
                alg.Padding = PaddingMode.Zeros;
                alg.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                var cipherText = Convert.FromBase64String(base64EncodedCipherText);
                using (ICryptoTransform decryptor = alg.CreateDecryptor())
                {
                    using (var ms = new MemoryStream(cipherText))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd().Replace("\0", string.Empty);
                            }
                        }
                    }
                }
            }
        }
        public static void Test()
        {
            string key = "yecpPqAJ+PnBMtggWVz42WME3TjhG313OhvBuUJOFtc=";
            string expectedPlainText = "HappyCoding";
            string base64EncodedSiteCipherText = "Lox/sfjNyXOzP9ZE8Fjj9REcuB+iJ1EXXuNjf2du29c=";
            string plainText = DecryptLikeSite(base64EncodedSiteCipherText, key);
            bool success = expectedPlainText == plainText;
        }
