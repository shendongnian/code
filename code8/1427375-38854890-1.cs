    try{
    HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
    webRequest.Proxy = WebRequest.DefaultWebProxy;
    webRequest.Credentials = new NetworkCredential("user", "password", "domain");
    webRequest.Proxy.Credentials = new NetworkCredential("user", "password", "domain");
    }catch(WebException ex){}
