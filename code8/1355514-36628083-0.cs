    public static string GenerateEmailToken()
    {
        // generate an email verification token for the user
        using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
        {
            byte[] data = new byte[16];
            provider.GetBytes(data);
            return Convert.ToBase64String(data);
        }
    }
