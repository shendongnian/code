    WebClient wc = new WebClient();  
    wc.UseDefaultCredentials = false;
    string host = "http://localhost"; //this comes from a function in my code
    var myCredentialCache = new System.Net.CredentialCache();
    myCredentialCache.Add(new Uri(host + "/"), "NTLM", new System.Net.NetworkCredential(accessUser, accessPassword, domain));
    
    wc.Credentials = myCredentialCache;
    var result = wc.DownloadFile(www);
