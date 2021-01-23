         var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
    services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true; 
    
                }) 
                    .AddSigningCredential(cert)
                     .AddCustomUserStore<IdentityServerConfigurationDbContext>()
                    // this adds the config data from DB (clients, resources)
                    .AddConfigurationStore(options =>
                    {
                        options.ConfigureDbContext = builder =>
                            builder.UseNpgsql(connectionString,
                                sql => sql.MigrationsAssembly(migrationsAssembly));
                    })
                    // this adds the operational data from DB (codes, tokens, consents)
                    .AddOperationalStore(options =>
                    {
                        options.ConfigureDbContext = builder =>
                            builder.UseNpgsql(connectionString,
                                sql => sql.MigrationsAssembly(migrationsAssembly));
    
                        // this enables automatic token cleanup. this is optional.
                        options.EnableTokenCleanup = true;
                        options.TokenCleanupInterval = 30;
                    });
