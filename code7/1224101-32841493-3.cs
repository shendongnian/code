    public string ExportPublicToXML(string publicKey)
    {
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider(new CspParameters()
        {
            ProviderType = 1
        });
        csp.ImportCspBlob(Convert.FromBase64String(publicKey));
        return csp.ToXmlString(false);
    }
