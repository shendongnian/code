    public override void Configure(Container container)
    {
        Plugins.Add(new AuthFeature(() => new AuthUserSession(),
            new IAuthProvider[] {
                new RoomsAuthProvider(),
            }));
    }
