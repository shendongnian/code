    public LoginController(IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
    {
        this.HttpContext = httpContextAccessor.HttpContext;
        this.logger = loggerFactory.CreateLogger(this.GetType());
    }
