    public void ConfigureServices(IServiceCollection services)
    {
        var builder = services.AddIdentityServer();
        builder.AddInMemoryClients(Clients.Get());
        builder.AddInMemoryScopes(Scopes.Get());
        builder.Services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
        builder.Services.AddTransient<IProfileService, ProfileService>();
    }
