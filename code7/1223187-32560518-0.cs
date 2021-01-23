      public byte[] Encrpyt(string unprotectedData)
        {
            try
            {
                var rawByte = Encoding.UTF8.GetBytes(unprotectedData);
                var protectedByte = ProtectedData.Protect(rawByte, mEntropy, DataProtectionScope.CurrentUser);
                return System.Convert.ToBase64String(protectedByte);
            }
            catch (CryptographicException e)
            {
                Log.Error("Unable to encrypt data: " + e.Message);
                return null;
            }
        }
    
        public string Decrpyt(string encryptedBase64)
        {
            try
            {
                var bytes = System.Convert.FromBase64String(encryptedBase64)
          
                var rawByte = ProtectedData.Unprotect(bytes , mEntropy, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(rawByte);
            }
            catch (CryptographicException e)
            {
                Log.Error("Unable to decrypt data: " + e.Message);
                return null;
            }
        }
