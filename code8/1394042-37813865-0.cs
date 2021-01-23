    public void ConfigureServices(IServiceCollection services)
    {
    
        //IServiceCollection acts like a container and you 
        //can register your classes like this:
    
        services.AddTransient<IEmailSender, AuthMessageSender>();
        services.Singleton<ISmsSender, AuthMessageSender>();
        services.AddScoped<ICharacterRepository, CharacterRepository>();
    
    }
