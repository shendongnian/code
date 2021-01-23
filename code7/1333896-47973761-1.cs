    var cert = LoadCertificate();
    if (cert == null)
    {
        services.AddIdentityServer()
            .AddTemporarySigningCredential()
            .AddAspNetIdentity<ApplicationUser>()
            .AddConfigurationStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
            .AddOperationalStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)));
    }
    else
    {
        services.AddIdentityServer()
            .AddSigningCredential(cert)
            .AddAspNetIdentity<ApplicationUser>()
            .AddConfigurationStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)))
            .AddOperationalStore(builder => builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationsAssembly)));
    }
