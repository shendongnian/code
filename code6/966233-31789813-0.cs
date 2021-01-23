    geolocator = new Geolocator();
    geolocator.DesiredAccuracy = PositionAccuracy.High;
    geolocator.ReportInterval = 2000;
    geolocator.PositionChanged += geolocator_PositionChanged;
    private void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
    try
    {
        Dispatcher.BeginInvoke(() =>
        {
            myPosition = args.Position.Coordinate.ToGeoCoordinate();
        });
    }
    catch(Exception ex)
    {
        if (ex.Data == null) throw;
        else MessageBox.Show("Exception while Tracking: " + ex.InnerException.ToString());
    }
    }
