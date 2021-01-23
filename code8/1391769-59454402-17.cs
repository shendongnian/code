    public MainWindowVM(IServiceFactory serviceFactory)
    {
    }
    private void OnHomeEvent()
    {
        CurrentView = serviceFactory.Get<ICategorySelectionVM>();
    }
