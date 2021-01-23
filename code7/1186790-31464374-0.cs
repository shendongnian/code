    async void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Data d = new Data();
        Geolocator locator = new Geolocator();
        try
        {
            Geoposition position = await locator.GetGeopositionAsync();
            // Get address data with MapLocationFinder
            var result = await MapLocationFinder.FindLocationsAtAsync(position.Coordinate.Point);
            if (result.Status == MapLocationFinderStatus.Success)
            {
                var address = result.Locations[0].Address;
                var zip = address.PostCode;
                d.zip = zip;
            }
            // These are deprecated as well. 
            // Use position.Coordinate.Point.Position.Latitude and
            // position.Coordinate.Point.Position.Longitude
            d.Latitude = position.Coordinate.Latitude;
            d.Longitude = position.Coordinate.Longitude;
            MessageBox.Show(d.zip);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    public class Data
    {
        public string zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
