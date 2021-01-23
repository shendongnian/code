    public string latitude, longitude;
     async private void GetLocation()
            {
            try
            {
                var geolocator = new Geolocator();
                if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] == true)
                {
                    Geoposition position = await geolocator.GetGeopositionAsync();
                    Geocoordinate coordinate = position.Coordinate;
                    latitude = Convert.ToString(Math.Round(coordinate.Latitude, 2));
                    longitude = Convert.ToString(Math.Round(coordinate.Longitude, 2));
                }
                else
                {
                    MessageBox.Show("Please enable location services to use this feature. You can turn it on from Settings.");
                }
            }
            catch (Exception)
            {
            }
        }
