        public static byte[] TripleDESEncrypt(string texto, byte[] key)
        {
            using (TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider())
            {
                byte[] iv_0 = { 0, 0, 0, 0, 0, 0, 0, 0 };
                byte[] toEncryptArray = Encoding.ASCII.GetBytes(texto);               
                tdes.IV = iv_0;
                //assign the secret key
                tdes.Key = key;
                tdes.Mode = CipherMode.CBC;
                tdes.Padding = PaddingMode.Zeros;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray =
                  cTransform.TransformFinalBlock(toEncryptArray, 0,
                  toEncryptArray.Length);
                
                //Clear to Best Practices
                tdes.Clear();
                         
                return resultArray;
            }
        }
