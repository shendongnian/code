    private static readonly Lazy<IHubContext> _hubCtx = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<MyHub>());
    
    protected virtual Task SendReportToAll(Report r)
    {
    	return _hubCtx.Value.Clients.All.EventToTriggerOnClient(r);
    }
    protected virtual Task SendReportToUser(Report r, string username)
    {
    	return _hubCtx.Value.Clients.User(username).EventToTriggerOnClient(r);
    }
