    RSAParameters keyParams;
    using (var rsa = new RSACryptoServiceProvider(2048))
    {
        try
        {
            keyParams = rsa.ExportParameters(true);
        }
        finally
        {
            rsa.PersistKeyInCsp = false;
        }
    }
    RsaSecurityKey key = new RsaSecurityKey(keyParams);
    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
