     public static byte[] EncryptImage(byte[] encryptedimage, string strCacheKey)
        {
            try
            {
                return ProtectedData.Protect(encryptedimage, GetToken(strCacheKey));
            }
            catch (Exception)
            {
            }
            return new byte[0];
        }
