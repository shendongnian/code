    private readonly Func<HttpContextBase> _httpContextFactory;
    private readonly ISessionContext _sessionContext;
    public ASHttpModule(Func<HttpContextBase> httpContextFactory,
        ISessionContext sessionContext)
    {
        this._httpContextFactory = httpContextFactory;
        this._sessionContext = sessionContext;
    }
    private void Context_BeginRequest(object sender, EventArgs e)
    {
       var httpContext = this._httpContextFactory();
       Stopwatch stopwatch = new Stopwatch();
       httpContext.Items["Stopwatch"] = stopwatch;
       stopwatch.Start();
    }
