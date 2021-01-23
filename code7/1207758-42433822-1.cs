        public RsaKey GetFromXmlString(string xmlString)
        {
            try
            {
                var rsaCsp = new RSACryptoServiceProvider(2048, new CspParameters() { KeyContainerName = "MyTableStorageRsaKey" });
                rsaCsp.FromXmlString(xmlString);
                rsaCsp.PersistKeyInCsp = false;
                return new RsaKey("MyTableStorageRsaKey", rsaCsp);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid rsa key xmlString provided", ex);
            }
        }
