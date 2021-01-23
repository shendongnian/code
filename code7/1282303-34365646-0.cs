    var accessStatus = await Geolocator.RequestAccessAsync();
    if (accessStatus == GeolocationAccessStatus.Allowed)
    {
        var geolocator = new Geolocator { DesiredAccuracyInMeters = 10 };
        var pos = await geolocator.GetGeopositionAsync();
        var myLocation = pos.Coordinate.Point;
        MyMap.MapServiceToken = "MyKey"; //Replace with your key
        MyMap.Center = myLocation;
        MyMap.ZoomLevel = 12;
    };
