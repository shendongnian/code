        public string X509_Decrypt(string inputString, string pathToCertFile, string password)
        {
            if (inputString == null)
            {
                return null;
            }
            X509Certificate2 certificate = new X509Certificate2(pathToCertFile, password, X509KeyStorageFlags.MachineKeySet);
            try
            {
                var cryptoProvider = (RSACryptoServiceProvider)certificate.PrivateKey;
                int dwKeySize = cryptoProvider.KeySize;
                int blockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
                int iterations = inputString.Length / blockSize;
                var arrayList = new ArrayList();
                for (int i = 0; i < iterations; i++)
                {
                    byte[] encryptedBytes = Convert.FromBase64String(
                        inputString.Substring(blockSize * i, blockSize));
                    Array.Reverse(encryptedBytes);
                    arrayList.AddRange(cryptoProvider.Decrypt(encryptedBytes, true));
                }
                return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
