    private void Process()
    {
    	while (HttpListener.IsListening)
    	{
		    var result = HttpListener.BeginGetContext(ContextReceived,     HttpListener);
    		if (WaitHandle.WaitAny(new[] { result.AsyncWaitHandle, _shutdown })     == 0)
	    		return;
    	}
    }
