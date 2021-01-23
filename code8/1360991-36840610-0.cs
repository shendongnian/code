    public ConstructorForModuleOrViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }
    
    private SomeCommandHandler()
    {
        var commandButton = // create button and wire up command here)
        _regionManager.AddViewToRegion(commandButton, "CustomModuleCommandRegion");
    }
