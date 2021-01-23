    List<BasicGeoposition> positions = new List<BasicGeoposition>();
    // Now add your positions:
    positions.Add(new BasicGeoposition(){ Latitude = lat, Longitude = long});   //<== this
    positions.Add(new BasicGeoposition(){ Latitude = lat, Longitude = long));  //<== and this
    Geopath path = new Geopath(positions);
    var line = new MapPolyline();
    // Set your path
    line.Path = path;
    line.StrokeColor = Colors.Red;
    line.StrokeThickness = 2;
    MyMap.MapElements.Add(line);
