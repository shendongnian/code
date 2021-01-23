    services.AddAuthorization(options =>
                {
                    options.AddPolicy("Role1", policy => policy.RequireRole("Role1");
                    options.AddPolicy("Role2", policy => policy.RequireRole("Role1", "Role2");
                    options.AddPolicy("Role3", policy => policy.RequireRole("Role1", "Role2", "Role3");
                });
