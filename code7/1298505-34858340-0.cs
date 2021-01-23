    protected override void ConfigureContainer()
    {
        base.ConfigureContainer();
        ViewModelLocationProvider.SetDefaultViewModelFactory( type => Container.Resolve( type ) );
    }
