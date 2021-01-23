    protected virtual void Application_BeginRequest()
    {
        HttpContext.Current.Items["_EntityContext"] = new EntityContext();
    }
    
    protected virtual void Application_EndRequest()
    {
        var entityContext = HttpContext.Current.Items["_EntityContext"] as EntityContext;
        if (entityContext != null)
            entityContext.Dispose();
    }
