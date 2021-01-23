    private static byte[] SignArbitrarily(byte[] data, X509Certificate2 cert)
    {
        Debug.Assert(data != null);
        Debug.Assert(cert != null);
        Debug.Assert(cert.HasPrivateKey);
        // .NET 4.6(.0):
        using (RSA rsa = cert.GetRSAPrivateKey())
        {
            if (rsa != null)
            {
                // You need to explicitly pick a hash/digest algorithm and padding for RSA,
                // these are just some example choices.
                return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
        // .NET 4.6.1:
        using (ECDsa ecdsa = cert.GetECDsaPrivateKey())
        {
            if (ecdsa != null)
            {
                // ECDSA signatures need to explicitly choose a hash algorithm, but there
                // are no padding choices (unlike RSA).
                return ecdsa.SignData(data, HashAlgorithmName.SHA256);
            }
        }
        // .NET 4.6.2 (currently in preview):
        using (DSA dsa = cert.GetDSAPrivateKey())
        {
            if (dsa != null)
            {
                // FIPS 186-1 (legacy) DSA does not have an option for the hash algorithm,
                //   SHA-1 was the only option.
                // FIPS 186-3 (current) DSA allows any of SHA-1, SHA-2-224, SHA-2-256,
                //   SHA-2-384, and SHA-2-512 (.NET does not support SHA-2-224).
                //   KeySize < 1024 is FIPS-186-1 mode, > 1024 is 186-3, and == 1024 can
                //   be either (depending on the hardware/software provider).
                // So, SHA-1 is being used in this example as the "most flexible",
                //   but may not currently be considered "secure".
                return dsa.SignData(data, HashAlgorithmName.SHA1);
            }
        }
        throw new InvalidOperationException("No algorithm handler");
    }
    // Uses the same choices as SignArbitrarily.
    private static bool VerifyArbitrarily(byte[] data, byte[] signature, X509Certificate2 cert)
    {
        Debug.Assert(data != null);
        Debug.Assert(signature != null);
        Debug.Assert(cert != null);
        using (RSA rsa = cert.GetRSAPublicKey())
        {
            if (rsa != null)
            {
                return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }
        }
        using (ECDsa ecdsa = cert.GetECDsaPublicKey())
        {
            if (ecdsa != null)
            {
                return ecdsa.VerifyData(data, signature, HashAlgorithmName.SHA256);
            }
        }
        using (DSA dsa = cert.GetDSAPublicKey())
        {
            if (dsa != null)
            {
                return dsa.VerifyData(data, signature, HashAlgorithmName.SHA1);
            }
        }
        throw new InvalidOperationException("No algorithm handler");
    }
