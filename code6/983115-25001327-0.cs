    {
        ...
        locator.DesiredAccuracy = PositionAccuracy.High;
        locator.MovementThreshold = 5d;
        // locator.ReportInterval = (uint)TimeSpan.FromSeconds(5).TotalMilliseconds; 
        locator.PositionChanged += RaiseLocationChanged;
        ...
    }
    private void RaiseLocationChanged(Geolocator sender, PositionChangedEventArgs args)
    {
        // Your reverse geocode etc. logic might go here...
        var location = CoordinateConverter.ConvertGeocoordinate(args.Position.Coordinate);
    }
