    public class ChromeTest
    {
        public static ChromiumWebBrowser Create(WebProxy proxy = null, Action<ChromiumWebBrowser> onInited = null)
        {
           var result = default(ChromiumWebBrowser);
            var settings = new CefSettings();
            var rc = new RequestContext();
            result = new ChromiumWebBrowser("about:blank", rc);
            if (proxy != null)
                result.RequestHandler = new _requestHandler(proxy?.Credentials as NetworkCredential);
            result.IsBrowserInitializedChanged += (s, e) =>
            {
                if (!e.IsBrowserInitialized)
                    return;
                var br = (ChromiumWebBrowser)s;
                if (proxy != null)
                {
                    var v = new Dictionary<string, object>
                    {
                        ["mode"] = "fixed_servers",
                        ["server"] = $"{proxy.Address.Scheme}://{proxy.Address.Host}:{proxy.Address.Port}"
                    };
                    if (!rc.SetPreference("proxy", v, out string error))
                        MessageBox.Show(error);
                }
                onInited?.Invoke(br);
            };
            return result;
        }
        private class _requestHandler : DefaultRequestHandler
        {
            private NetworkCredential _credential;
            public _requestHandler(NetworkCredential credential = null) : base()
            {
                _credential = credential;
            }
            public override bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
            {
                if (isProxy == true)
                {
                    if (_credential == null)
                        throw new NullReferenceException("credential is null");
                    callback.Continue(_credential.UserName, _credential.Password);
                    return true;
                }
                return false;
            }
        }
    }
