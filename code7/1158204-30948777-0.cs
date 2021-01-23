    var cacheSvcUri = "<your-cache-name>.cache.windows.net";
    
    // Setup DataCacheSecurity configuration
    string cacheSvcAcsKey = "<your-acs-key>";
    var secureAcsKey = new SecureString();
    foreach (char c in cacheSvcAcsKey)
    {
    secureAcsKey.AppendChar(c);
    }
    secureAcsKey.MakeReadOnly();
    
    // Setup the DataCacheFactory configuration
    DataCacheFactoryConfiguration dcfConfig = new DataCacheFactoryConfiguration();
    
    // Set autodiscover for in-role
    
    dcfConfig.AutoDiscoverProperty = new DataCacheAutoDiscoverProperty(true, cacheSvcUri);
    
    DataCacheSecurity factorySecurity = new DataCacheSecurity(secureAcsKey);
    dcfConfig.SecurityProperties = factorySecurity;
    
    // Create a configured DataCacheFactory object.
    DataCacheFactory dcf= new DataCacheFactory(dcfConfig); // make the DataCacheFactory static as it connects to the cache cluster.
    
    // Get a cache client for the default cache.
    DataCache defaultCache = dcf.GetDefaultCache();
    
    defaultCache.Put("One", 1);
    defaultCache.Put("Two", 2);
