    public MainWindowVM(IServiceFactory serviceFactory) // constructor
    {
    }
    private void OnHomeEvent()
    {
        CurrentView = serviceFactory.Get<ICategorySelectionVM>();
    }
