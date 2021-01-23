    private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
    {
        if (e.Position.Location.HorizontalAccuracy > 500)
        {
            return;
        }
        String lat = e.Position.Location.Latitude.ToString();
        String lon = e.Position.Location.Longitude.ToString();
        MessageBox.Show(lat + "+" + lon);
        // Stop receiving updates after the first one.
        watcher.Stop();
    }
