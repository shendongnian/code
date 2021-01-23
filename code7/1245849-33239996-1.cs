    public static ViewDataDictionary<T> CreateViewDataDictionary<T>(this HttpContext httpContext, T model)
    {
        var modelMetadataProvider = httpContext.ApplicationServices.GetRequiredService<IModelMetadataProvider>();
        return new ViewDataDictionary<T>(modelMetadataProvider, new ModelStateDictionary())
        {
            Model = model
        };
    }
    public IActionResult SomeAction()
    {
        var viewDataDictionary = this.Context.CreateViewDataDictionary(new FooModel());
        
        ...
    }
