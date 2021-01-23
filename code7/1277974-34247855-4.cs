    public byte[] SignData(RSAParameters privateParameters, byte[] data)
        {
            using (var csp = new RSACryptoServiceProvider())
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                csp.ImportParameters(privateParameters);
                return csp.SignData(data, sha1);
            }
        }
