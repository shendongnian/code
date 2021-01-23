    class ChromeBrowserRequestHandler: IRequestHandler
        {
            public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                return false;
            }
    
            public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
            {
                return false;
            }
    
            public bool OnBeforePluginLoad(IWebBrowser browser, string url, string policyUrl, WebPluginInfo info)
            {
                return false;
            }
    
            public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
            {
                var headers = request.Headers;
    			headers["Custom-Header"] = "My Custom Header";
    			request.Headers = headers;
    			
                return CefReturnValue.Continue;
            }
    
            public bool OnCertificateError(IWebBrowser browser, CefErrorCode errorCode, string requestUrl)
            {
                return false;
            }
    
            public void OnPluginCrashed(IWebBrowser browser, string pluginPath)
            {
            }
    
            public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
            {
            }
    
            public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) 
            { 
                return null; 
            }
    
            public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback) 
            {
                return false; 
            }
    
            public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture) 
            {
                return false; 
            }
    
            public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath) 
            {
            }
    
            public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url) 
            {
                return false;
            }
    
            public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback) 
            {
                return false;
            }
    
            public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser) 
            { 
            }
    
            public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
            { 
            }
    
            public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, ref string newUrl) 
            { 
            }
    
            public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response) 
            {
                return false;
            }
        }
