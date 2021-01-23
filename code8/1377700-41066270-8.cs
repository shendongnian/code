    // configure identity server with in-memory stores, keys, clients and scopes
    services.AddDeveloperIdentityServer(options =>
        {
            options.IssuerUri = "SomeSecureCompany";
        })
        .AddInMemoryScopes(Scopes.Get())
        .AddInMemoryClients(Clients.Get())
        .AddInMemoryUsers(Users.Get())
