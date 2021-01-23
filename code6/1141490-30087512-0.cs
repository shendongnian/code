    var sslAssembly = Assembly.GetAssembly(typeof(SslStream));
       
    var sslSessionCacheClass = sslAssembly.GetType("System.Net.Security.SslSessionsCache");
    var cachedCredsInfo = sslSessionCacheClass.GetField("s_CachedCreds", BindingFlags.NonPublic | BindingFlags.Static);
    var cachedCreds = (Hashtable)cachedCredsInfo.GetValue(null);
    cachedCreds.Clear();
