    ...
    // The UI will use data binding to PageState to show 
    // UI specific for the initialization phase.
    public PageState PageState {get; private set {.../*include property change notification */...};}
    // The UI will use data binding to ErrorMessage as needed.
    public string ErrorMessage {get; private set {.../*include property change notification */...};}
    ...
    protected async override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        await InitializeAsync();
    }
    private async Task InitializeAsync()
    {
        try
        {
            // Have the UI bind to 
            PageState = PageState.InitializingInProgress;
        
            await SQLiteData(); 
            GetConnectionList();
            ...
            PageState = PageState.InitializedOk;
        }
        catch(...)
        {
            PageState = PageState.InitializedWithError;
            ErrorMessage = ...
        }
    }
}
