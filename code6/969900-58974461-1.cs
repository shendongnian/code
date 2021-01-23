    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<MyCookieAuthenticationEvents>();
        services.ConfigureApplicationCookie(o =>
        {
            o.EventsType = typeof(MyCookieAuthenticationEvents);
        });
    }
