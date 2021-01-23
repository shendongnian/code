    public IAutoQueryDb AutoQuery { get; set; }
    public object Get(ResourceTimeExceptionQuery request)
    { 
        var q = AutoQuery.Create(request, base.Request);
    }
