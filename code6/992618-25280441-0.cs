     geolocator = new Geolocator();
     geolocator.PositionChanged -= geolocator_PositionChanged;
    
    void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
    {
        Dispatcher.BeginInvoke(() =>
        {
            LatitudeTextBlock.Text = args.Position.Coordinate.Latitude.ToString("0.00");
            LongitudeTextBlock.Text = args.Position.Coordinate.Longitude.ToString("0.00");
        });
    }
