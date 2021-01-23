    public override void Configure(Container container)
    {
        container.Register(_init);
        container.Register(_activeForm);
    }
