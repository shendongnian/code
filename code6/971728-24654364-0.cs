    private async void OneShotLocation_Click(object sender, RoutedEventArgs e)
    {
        if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] != true)
        {
            // The user has opted out of Location.
            return;
        }
        Geolocator geolocator = new Geolocator();
        geolocator.DesiredAccuracyInMeters = 50;
        try
        {
            Geoposition geoposition = await geolocator.GetGeopositionAsync(
                maximumAge: TimeSpan.FromMinutes(5),
                timeout: TimeSpan.FromSeconds(10)
                );
            LatitudeTextBlock.Text = geoposition.Coordinate.Latitude.ToString("0.00");
            LongitudeTextBlock.Text = geoposition.Coordinate.Longitude.ToString("0.00");
        }
        catch (Exception ex)
        {
            if ((uint)ex.HResult == 0x80004004)
            {
                // the application does not have the right capability or the location master   switch is off
                StatusTextBlock.Text = "location  is disabled in phone settings.";
            }
            //else
            {
                // something else happened acquring the location
            }
        }
    }
