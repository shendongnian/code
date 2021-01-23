    private static object AuthenticationLocker = new object();
    private string GetToken(string userId)
    {
    	lock (AuthenticationLocker)
    	{
    		var token = _cm.Cache.Get<MyToken>(userId);
    		if (token != null) return token;
    		token = base.Logon(userId, password);
    		if (token != null)
    		{
    			_cm.Cache.Add(userId, token);
    		}
    		return token;
    	}
    }
