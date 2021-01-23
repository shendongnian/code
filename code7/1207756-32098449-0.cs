    IKey tableStorageKey = GetTableStorageKey()
    _tableRequestOptions = new TableRequestOptions
    {
        EncryptionPolicy = new TableEncryptionPolicy(tableStorageKey, null)
    };
    ...
    private IKey GetTableStorageKey()
    {
        using (var rsaCsp = new RSACryptoServiceProvider(2048))
        {
            try
            {
                //it doesn't really matter where you get your RsaCsp from, I have mine in my webconfig
                XmlDocument doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                XmlElement node = doc.SelectSingleNode("/configuration/MyTableStorageRsaKey") as XmlElement;
                            
                rsaCsp.FromXmlString(node.OuterXml);
                return new RsaKey("MyTableStorageRsaKey", rsaCsp);
            }
            finally
            {
                rsaCsp.PersistKeyInCsp = false;
            }
        }
    }
    
            
            
