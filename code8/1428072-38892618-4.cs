    public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
    {
        Value = (suspensionState.ContainsKey(nameof(Value))) ? suspensionState[nameof(Value)]?.ToString() : parameter?.ToString();
        var accessStatus = await Geolocator.RequestAccessAsync();
        var locationService = new LocationService();
        var pos = locationService.Position;
        //StartTracking();
        await Task.CompletedTask;
    }
