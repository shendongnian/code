    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
        Container.RegisterType<ICustomer, Customer>();
    }
