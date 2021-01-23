    public IContainer CurrentNestedContainer
    {
    	get
    	{
    		if (HttpContext == null)
    			return null;
    
    		return (IContainer)HttpContext.Items[NestedContainerKey];
    	}
    	set
    	{
    		HttpContext.Items[NestedContainerKey] = value;
    	}
    }
    private HttpContextBase HttpContext
    {
    	get
    	{
    		var ctx = Container.TryGetInstance<HttpContextBase>();
    		if (ctx == null && System.Web.HttpContext.Current == null)
    			return null;
    
    		return ctx ?? new HttpContextWrapper(System.Web.HttpContext.Current);
    	}
    }
