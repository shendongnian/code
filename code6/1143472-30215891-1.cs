        public string X509_Encrypt(string inputString, string pathToCertFile, string password)
        {
            if (inputString == null)
            {
                return null;
            }
            X509Certificate2 certificate = new X509Certificate2(pathToCertFile, password, X509KeyStorageFlags.MachineKeySet);
            try
            {
                // TODO: Add Proper Exception Handlers
                var rsaCryptoServiceProvider = (RSACryptoServiceProvider)certificate.PublicKey.Key;
                int keySize = rsaCryptoServiceProvider.KeySize / 8;
                byte[] bytes = Encoding.UTF32.GetBytes(inputString);
                int maxLength = keySize - 42;
                int dataLength = bytes.Length;
                int iterations = dataLength / maxLength;
                var stringBuilder = new StringBuilder();
                for (int i = 0; i <= iterations; i++)
                {
                    var tempBytes = new byte[ (dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                    
                    Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                    byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                    Array.Reverse(encryptedBytes);
                    stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
                }
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
