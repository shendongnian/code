    public static IServiceCollection AddMyServices(this IServiceCollection services) {
        services.AddMyRepositories();
        services.AddScoped<IMyService, MyService>();
        //...add other services
    }
