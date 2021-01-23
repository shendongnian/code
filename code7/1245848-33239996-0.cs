    public IActionResult SomeAction()
    {
        var modelMetadataProvider = this.Context.ApplicationServices.GetRequiredService<IModelMetadataProvider>();
        var viewDataDictionary = new ViewDataDictionary<FooModel>(modelMetadataProvider, new ModelStateDictionary());
        viewDataDictionary.Model = new FooModel();
        ...        
    }
