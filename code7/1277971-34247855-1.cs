    public bool VerifySignature(RSAParameters publicParameters, byte[] data, byte[] signature)
    {
        using (var csp = new RSACryptoServiceProvider())
        using (var sha1 = new SHA1CryptoServiceProvider())
        {
            csp.ImportParameters(publicParameters);
            return csp.VerifyData(data, sha1, signature));
        }
    }
