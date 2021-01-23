       private bool Verify(string key, string signature, string data)
       {
            CspParameters cspParams = new CspParameters { ProviderType = 1 };
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(cspParams);
            rsaProvider.ImportCspBlob(Convert.FromBase64String(key));
            byte[] signatureBytes = Convert.FromBase64String(signature);
            var encoder = new UTF8Encoding();
            byte[] dataBytes = encoder.GetBytes(data);
            return rsaProvider.VerifyData(dataBytes, new SHA1CryptoServiceProvider(), signatureBytes);
        }
