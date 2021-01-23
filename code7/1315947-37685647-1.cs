    public void ConfigureServices(IServiceCollection services)
    {
        //Other Code here......
    
        var ioc = new PearIoc(services);
        //ioc.AddTransient<IEmailSender, AuthMessageSender>();
        //ioc.AddTransient<ISmsSender, AuthMessageSender>();
    
        ioc.WithStandardConvention();
        ioc.WithMediatR();
        ioc.RunConfigurations();
    }
