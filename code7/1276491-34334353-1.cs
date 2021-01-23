    public static byte[] DecryptImage(byte[] decryptedimage, string strCacheKey)
        {
            try
            {
                return ProtectedData.Unprotect(decryptedimage, GetToken(strCacheKey));
            }
            catch (Exception)
            {
            }
            return new byte[0];
        }
