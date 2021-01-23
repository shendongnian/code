    private async void Ellipse_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        Geolocator geolocator = new Geolocator();
        geolocator.DesiredAccuracyInMeters = 50;
        try
        {
            DisplayProgressIndicator(true, "Finding current location..."); // < SET THE PROGRESS INDICATOR
            Geoposition geoposition = await geolocator.GetGeopositionAsync(
                maximumAge: TimeSpan.FromMinutes(5),
                timeout: TimeSpan.FromSeconds(10)
                );
            delta_y = geoposition.Coordinate.Latitude - y;
            delta_x = geoposition.Coordinate.Longitude - x;
            Path.Visibility = Visibility.Visible;
            DisplayProgressIndicator(false); // << UNSET PROGRESS INDICATOR
        }
        catch (Exception ex)
        {
            if ((uint)ex.HResult == 0x80004004)
            {
                MessageBox.Show("Location is disabled in phone settings.");
                return;
            }                
        }
    }
