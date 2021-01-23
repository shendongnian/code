    #if DEBUG
    ServicePointManager.ServerCertificateValidationCallback += ValidationCallback; 
    #endif
    var webRequest = HttpWebRequest.Create("https://your.url");
    ...
    
    #if DEBUG
    bool ValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }
    #endif
