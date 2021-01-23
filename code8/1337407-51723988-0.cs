    public class ChromeTest
    {
        static object o = new object();
        public static ChromiumWebBrowser Create(WebProxy proxy = null, Action<ChromiumWebBrowser> onInited = null)
        {
            var result = default(ChromiumWebBrowser);
            var settings = new CefSettings();
            lock (o)
            {
                result = new ChromiumWebBrowser("about:blank", new RequestContext());
                if (proxy != null)
                    result.RequestHandler = new _requestHandler(proxy?.Credentials as NetworkCredential);
                result.IsBrowserInitializedChanged += (s, e) =>
                {
                    if (!e.IsBrowserInitialized)
                        return;
                    var br = (ChromiumWebBrowser)s;
                    if (proxy != null)
                    {
                        Cef.UIThreadTaskFactory.StartNew(delegate
                        {
                            var v = new Dictionary<string, object>
                            {
                                ["mode"] = "fixed_servers",
                                ["server"] = $"{proxy.Address.Scheme}://{proxy.Address.Host}:{proxy.Address.Port}"
                            };
                            if (!br.GetBrowser().GetHost().RequestContext.SetPreference("proxy", v, out string error))
                                MessageBox.Show(error);
                        }).Wait();
                    }
                    onInited?.Invoke(br);
                };
                return result;
            }
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
                        throw new NullReferenceException("Не указаны учетные данные");
                    callback.Continue(_credential.UserName, _credential.Password);
                    return true;
                }
                return false;
            }
        }
        private class _stringVisitor : IStringVisitor
        {
            private readonly Action<string> callback;
            public _stringVisitor(Action<string> onVisit)
            {
                callback = onVisit;
            }
            public void Dispose()
            {
            }
            public void Visit(string str)
            {
                callback(str);
            }
        }
    }
