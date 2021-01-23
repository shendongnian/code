    public async void getposition() {
        Geolocator geolocator = new Geolocator();
        Geoposition geoposition = null;
        geoposition = await geolocator.GetGeopositionAsync();
        MyMap.Center = geoposition.Coordinate.Point;
        // zoom level
        MyMap.ZoomLevel = 15;
    }
