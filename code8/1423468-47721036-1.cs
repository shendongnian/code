    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
        if (serviceScope.ServiceProvider.GetService<YourAppDbContext>() != null) 
        {
          var ctx = serviceScope.ServiceProvider.GetService<YourAppDbContext>();
          if (AnAuthenticateMethodHereMaybe(ctx, username, password)) {
            return Task.FromResult(new ClaimsIdentity(new 
    GenericIdentity(username, "Token"), new Claim[] { }));
          }
        }
      }
