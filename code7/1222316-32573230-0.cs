    public OwinCookieUserService(IOwinContext owinContext)
    {
    	if (owinContext == null) throw new ArgumentNullException(nameof(owinContext));	
    	_owinContext = owinContext;
    }
