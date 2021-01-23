    public override Task OnConnected()
    {
    	var windowsName = Context.Headers.Get("windowsName");
    	Groups.Add(Context.ConnectionId, windowsName);
    
    	return base.OnConnected();
    }
