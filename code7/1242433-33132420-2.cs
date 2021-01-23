    public static void AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IMyCountriesRepository, MyCountriesRepository>();
        services.AddScoped<IEmailer, Emailer>();
        ...
    }
    //register all your services just by running the ext method:
    services.AddMyServices();
