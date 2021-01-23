    public override void Configure(Container container)
    {
        container.Register<ILayout>(c => ...);
        container.Register<Init>(c => ...);
    }
