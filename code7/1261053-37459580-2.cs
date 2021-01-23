    private IActorStateManager _stateManager;
    // Unit tests can inject mock here.
    public MyActor(IActorStateManager stateManager = null)
    {
        _stateManager = stateManager;
    }
    protected override async Task OnActivateAsync()
    {
        if (_stateManager == null)
        {
            _stateManager = StateManager;
        }
    }
