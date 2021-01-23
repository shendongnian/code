    services.AddAuthorization(options =>
    {
        UserDbContext context = ...;
        foreach(var permission in context.Permissions) 
        {
            // assuming .Permission is enum
            options.AddPolicy(permission.Permission.ToString(),
                policy => policy.Requirements.Add(new PermissionRequirement(permission.Permission)));
        }
    });
    services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
