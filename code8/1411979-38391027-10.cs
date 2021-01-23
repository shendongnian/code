    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("TeamMember",
                              policy => policy.Requirements.Add(new TeamMemberRequirement()));
        });
    
        services.AddSingleton<IAuthorizationHandler, TeamMemberHandler>();
    }
