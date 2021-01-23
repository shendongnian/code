    private bool VerifySignature(byte[] data, byte[] signature)
    {
        try
        {
            // new cannot return null, so no point in a null check. It would have thrown.
            using (X509Certificate certificate = new X509Certificate("cert_filename.pem"))
            using (ECDsa ecdsa = certificate.GetECDsaPublicKey())
            using (RSA rsa = certificate.GetRSAPublicKey())
            // Improved DSA is 4.6.2
            {
                // You said the cert was ECDSA-SHA1, but that doesn't mean the original data was.
                // I assumed it was.
                if (ecdsa != null)
                    return ecdsa.VerifyData(data, signature, HashAlgorithmName.SHA1);
                if (rsa != null)
                    return rsa.VerifyData(data, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
    
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
