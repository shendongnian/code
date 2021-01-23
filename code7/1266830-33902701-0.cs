    public static void Read()
    {
    	X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    
    	store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    
    	foreach (X509Certificate2 mCert in store.Certificates)
    	{
    		//Find Container name?
    
    		var privateKey = mCert.PrivateKey as RSACryptoServiceProvider;
    
    		var uniqueKeyContainerName = privateKey.CspKeyContainerInfo.UniqueKeyContainerName;
    		var keyContainerName = privateKey.CspKeyContainerInfo.KeyContainerName;
    		var ProviderName = privateKey.CspKeyContainerInfo.ProviderName;
    		// etc.
    	}
    }
