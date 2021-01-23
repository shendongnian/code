    public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
    {
        if (suspensionState.Any())
        {
            Value = suspensionState[nameof(Value)]?.ToString();
        }
        Views.Shell.Instance.RefreshEvent += Refresh;
        await Task.CompletedTask;
    }
    
    public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
    {
        args.Cancel = false;
        Views.Shell.Instance.RefreshEvent -= Refresh;
        await Task.CompletedTask;
    }
    
    private void Refresh()
    {
        //TODO
    }
