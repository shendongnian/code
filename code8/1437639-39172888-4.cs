    public SqlStringLocalizerFactory(IHttpContextAccessor _accessor)
    {
       _accessor= accessor;
    }
    public void SomeMethod()
    {
        var tenant = _accessor.HttpContext.RequestServices
                .GetRequiredService<AppTenant>();
    }
