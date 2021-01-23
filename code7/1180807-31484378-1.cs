    public async void MyLocationFinder()
        {
            Geolocator MyGeolocator = new Geolocator();
            MyGeolocator.DesiredAccuracyInMeters = 50;
            try
            {
                Geoposition MyGeoposition = await MyGeolocator.GetGeopositionAsync(
                   maximumAge: TimeSpan.FromMinutes(5),
                   timeout: TimeSpan.FromSeconds(10) );
                LatitudeTextBlock.Text = MyGeoposition.Coordinate.Latitude.ToString("0.00");
                LongitudeTextBlock.Text = MyGeoposition.Coordinate.Longitude.ToString("0.00");
            }
            catch (UnauthorizedAccessException)
            {
                //The app doesn't has the right capability or the location master switch is off
                StatusTextBlock.Text = "Location is Disabled in phone storage.";
            }
        }
