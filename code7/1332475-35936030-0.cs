    // Add defaulted parameter to base class to allow modelFactory creation
    // to be overridden/injected (this will prevent the current default behaviour
    // when fetching the factory, if a non-null is passed in)
    public BaseApiController(IRTWRepository repository,IConfiguration configuration, 
                             IModelFactory modelFactory = null)
    {
        _modelFactory = modelFactory;
    }
