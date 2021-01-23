        [TestMethod]
        public void windows()
        {
            byte[] KEY = { 98, 193, 95, 78, 211, 151, 118, 57, 179, 5, 85, 181, 133, 20, 94, 101, 184, 175, 94, 164, 150, 119, 75, 207, 189, 178, 21, 213, 13, 217, 174, 44 };
            byte[] IV = { 1, 199, 179, 189, 160, 220, 229, 238, 179, 14, 255, 147, 187, 49, 179, 134 };
            byte[] input = System.Text.Encoding.UTF8.GetBytes("test");
            string win = Convert.ToBase64String(Encrypt_win(input, KEY, IV));
            string bc = Convert.ToBase64String(Encrypt_bc(input, KEY, IV));
            
            Assert.AreEqual(win, "8jykPv2OSILKjJwvgLRr1w==");
            Assert.AreEqual(bc, "8jykPv2OSILKjJwvgLRr1w==");
        }
        //private static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        private static byte[] Encrypt_win(byte[] input, byte[] Key, byte[] IV)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(input, 0, input.Length);
                        /*
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //swEncrypt.Write(plainText);
                            swEncrypt.Write(input);
                        }
                        */
                    }
                    return outputStream.ToArray();
                }
            }
        }
        private static byte[] Encrypt_bc(byte[] input, byte[] key, byte[] IV)
        {
            var keyParameter = new KeyParameter(key);
            var parameters = new ParametersWithIV(keyParameter, IV);
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(new AesEngine()), new Pkcs7Padding());
            cipher.Init(true, parameters);
            var rsl = new byte[cipher.GetOutputSize(input.Length)];
            var outOff = cipher.ProcessBytes(input, 0, input.Length, rsl, 0);
            cipher.DoFinal(rsl, outOff);
            return rsl;
        }
