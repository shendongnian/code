    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
    webRequest.Method = WebRequestMethods.Http.Get;
    NetworkCredential nc = new NetworkCredential("theUsername", "thePassword");
    webRequest.Credentials = nc;
    webRequest.PreAuthenticate = true; 
    RequestState rs = new RequestState();
    rs.Request = webRequest;
    WebResponse response;
    IAsyncResult r = (IAsyncResult)webRequest.BeginGetResponse(x => response = webRequest.EndGetResponse(x), rs);
    Thread.Sleep(10000);
    
