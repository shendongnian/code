    class BearerAuthResourceRequestHandler : ResourceRequestHandler
        {
            public BearerAuthResourceRequestHandler(string token)
            {
                _token = token;
            }
    
            private string _token;
            
            protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
            {
                if (!string.IsNullOrEmpty(_token))
                {
                    var headers = request.Headers;
                    headers["Authorization"] = $"Bearer {_token}";
                    request.Headers = headers;
                    return CefReturnValue.Continue;
                }
                else return base.OnBeforeResourceLoad(chromiumWebBrowser, browser, frame, request, callback);
            }
    
        }
        class BearerAuthRequestHandler : RequestHandler
        {
            public BearerAuthRequestHandler(string token)
            {
                _token = token;
            }
    
            private string _token;
    
            protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
            {
                if (!string.IsNullOrEmpty(_token)) return new BearerAuthResourceRequestHandler(_token);
                else return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
            }
        }
