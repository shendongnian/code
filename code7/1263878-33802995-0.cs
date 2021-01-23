    private IWebProxy _proxy;
    protected IWebProxy Proxy
    {
        get
        {
            if (_proxy == null)
            {
                _proxy = HttpWebRequest.DefaultWebProxy;
                _proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            return _proxy;
        }
    }
