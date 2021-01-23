    public static byte[] RSAEncrypt(
        byte[] byteEncrypt,
        RSAParameters rsaInfo,
        RSAEncryptionPadding padding)
    {
        try
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportParameters(rsaInfo);
                return rsa.Encrypt(byteEncrypt, padding);
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
