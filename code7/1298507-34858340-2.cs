    public void Initialize()
    {
        // Register services
        _unityContainer.RegisterType<IGameClock, LocalGameClock>( new ContainerControlledLifetimeManager() );
        _unityContainer.RegisterType<IWorldStateService, LocalWorldStateService>( new ContainerControlledLifetimeManager() );
    }
