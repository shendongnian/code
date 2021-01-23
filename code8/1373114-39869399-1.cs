    public Guid CreateCryptographicallySecureGuid()
    {
        using (var provider = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            var bytes = new byte[16];
            provider.GetBytes(bytes);
            return new Guid(bytes);
        }
    }
