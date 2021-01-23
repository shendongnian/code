    YouTubeRequest request = new YouTubeRequest(settings);
    GDataRequestFactory f = (GDataRequestFactory) request.Service.RequestFactory;
    IWebProxy iProxy = WebRequest.DefaultWebProxy;
    WebProxy myProxy = new WebProxy(iProxy.GetProxy(query.Uri));
    // potentially, setup credentials on the proxy here
    myProxy.Credentials = CredentialsCache.DefaultCredentials;
    myProxy.UseDefaultCredentials = true;
    f.Proxy = myProxy;
