    var builder = services.AddIdentityServer(options =>
    {
        options.SigningCertificate = cert;
    });
    
    builder.AddInMemoryClients(Clients.Get());
    builder.AddInMemoryScopes(Scopes.Get());
    //** this piece of code DI's the UserService into IdentityServer **
    builder.Services.AddTransient<IUserService, UserService>();
    //for clarity of the next piece of code
    services.AddTransient<IUserRepository, UserRepository>();
