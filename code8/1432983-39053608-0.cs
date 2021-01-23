    private IHttpContextAccessor context;
    public SomeRepo(IHttpContextAccessor context)
    {
        this.context = context;
    }
    //in your method
    var userName = this.context.HttpContext.User.Identity.Name;
