    public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
    {
        Value = (suspensionState.ContainsKey(nameof(Value))) ? suspensionState[nameof(Value)]?.ToString() : parameter?.ToString();
    
        StartTracking();
    
        await Task.CompletedTask;
    }
    private async void StartTracking()
    {
        // Request permission to access location
        var accessStatus = await Geolocator.RequestAccessAsync();
    
        switch (accessStatus)
        {
            case GeolocationAccessStatus.Allowed:
                _cts = new CancellationTokenSource();
                CancellationToken token = _cts.Token;
                _geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };
                Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);
                UpdateLocationData(pos);
                // Subscribe to PositionChanged event to get updated tracking positions
                _geolocator.PositionChanged += OnPositionChanged;
    
                // Subscribe to StatusChanged event to get updates of location status changes
                _geolocator.StatusChanged += OnStatusChanged;
                break;
    
            case GeolocationAccessStatus.Denied:
                break;
    
            case GeolocationAccessStatus.Unspecified:
                break;
        }
    }
