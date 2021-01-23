    private readonly ILifetimeScope _hubLifetimeScope;
    private readonly IEntityService<Update> _updateService; 
    public UpdateHub(ILifetimeScope lifetimeScope)
    {
       //the AutofacWebRequest is important. It will not work without it
        _hubLifetimeScope = lifetimeScope.BeginLifetimeScope("AutofacWebRequest");
        _updateService = _hubLifetimeScope.Resolve<IEntityService<Update>>();
    }
