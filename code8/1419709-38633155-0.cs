    var geolocator = new Geolocator();
    geolocator.DesiredAccuracyInMeters = 500;
    geolocator.MovementThreshold = 50;
    geolocator.ReportInterval = 1000;
        
    position = await geolocator.GetGeopositionAsync();
    var js = $"var pos = new google.maps.LatLng({position.Coordinate.Point.Position.Latitude}, {position.Coordinate.Point.Position.Longitude});";
    
    await webView.InvokeScriptAsync("eval", new List<string>() { js });
