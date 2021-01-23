    public SqlStringLocalizerFactory(IHttpContextAccessor _accessor)
    {
       _accessor= accessor;
    }
    public void SomeMethod()
    {
        var scopedService = _accessor.HttpContext.RequestServices
                .GetRequiredService<AppTenant>();
    }
