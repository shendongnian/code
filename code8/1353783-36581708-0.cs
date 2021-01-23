    public AppHost()
        : base("My Services", typeof(MyServices).Assembly)
    {
        typeof(Authenticate)
            .AddAttributes(new ExcludeAttribute(Feature.Metadata));
    }
