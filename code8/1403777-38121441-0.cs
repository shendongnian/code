    public string PublicKeyEncrypt(string plaintext, Stream publickey)
    {
        try
        {
            var rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(publickey);
            var rsaParameters = new RSAParameters();
            rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
            rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            return Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), true));
        }
        catch (Exception e)
        {
            // Whatever
        }
    }
