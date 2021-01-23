        app.Use(async (context, next) =>
        {
            if (!context.User.Identities.Any(i => i.IsAuthenticated))
            {
                context.User = new ClaimsPrincipal(new GenericIdentity("Unknown"));
            }
            await next.Invoke();
        });
