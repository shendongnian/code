    private Geolocator _geolocator = null;
    private uint _desireAccuracyInMetersValue = 0;
    
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        try
        {
            var _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;
            _geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };
            Geoposition pos = await _geolocator.GetGeopositionAsync().AsTask(token);
    
            // Subscribe to PositionChanged event to get updated tracking positions
            _geolocator.PositionChanged += OnPositionChanged;
    
            // Subscribe to StatusChanged event to get updates of location status changes
            _geolocator.StatusChanged += OnStatusChanged;
        }
        catch (Exception ex)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
        }
    }
