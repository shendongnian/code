    public async void GetSinglePositionAsync()
    {
        Geolocator myGeolocator = new Geolocator();
        Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
        Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
        GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
    }
