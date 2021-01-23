    public void SendRequest()
    {
        try
        {
    		ServicePointManager.Expect100Continue = true;
    		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
    
            var handler = new WebRequestHandler();
    		.....
    	}
    	..
    }
