    public void Configuration(IAppBuilder app)
    {    
        var kernel = new StandardKernel();
        // register IValidateApiTokenService
        var config = new HttpConfiguration();
        config.Filters.Add(new ApiAuthorizeFilter(kernel.Get<IValidateApiTokenService>());
    }
