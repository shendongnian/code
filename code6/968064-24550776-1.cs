    private async void Maps_GeoCoding(string sender)
        {
            var myAddress = new List<String>();
            var myGeolocator = new Geolocator();
            var myGeoposition = await myGeolocator.GetGeopositionAsync();
            var myGeocoordinate = myGeoposition.Coordinate;
            MyGeoCoordinate =
                CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            if (MyGeoCoordinate == null) return;
            var geoQuery = new GeocodeQuery { SearchTerm = sender, GeoCoordinate = MyGeoCoordinate };
            var locations = await geoQuery.GetMapLocationsAsync();
            var location = locations.FirstOrDefault();
            if (location != null)
            {
                myAddress.Add(location.Information.Address.City + " " + location.Information.Address.Street + " " + location.Information.Address.HouseNumber);
                MapWithMyLocation.Center = location.GeoCoordinate;
            }
            TxtSearch.ItemsSource = myAddress;
        }
