    GeoCoordinateWatcher _geoWatcher = new GeoCoordinateWatcher();
    _geoWatcher.PositionChanged += GeoWatcher_PositionChanged;
    
    bool isStarted = _geoWatcher.TryStart(suppressPermissionPrompt, timeOut);
    _currentLocation = (isStarted && !_geoWatcher.Position.Location.IsUnknown) ? _geoWatcher.Position.Location: new GeoCoordinate();
                
    private void GeoWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
    {
        _currentLocation = e.Position.Location;
        _geoWatcher.Stop();
    }
