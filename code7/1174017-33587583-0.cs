    Pushpin pin = new Pushpin()
            {
                Content = "MyPushpin",
                Background = new SolidColorBrush(Colors.Blue),
                BorderBrush = new SolidColorBrush(Colors.White)
            };
    MapOverlay relay = new MapOverlay()
            {
                Content = pin,
                PositionOrigin = new Point(0.5, 0.5),
                GeoCoordinate = myGeoCoordinates // myGeoCoordinates is an object of the class GeoCoordinate
            };
    MapLayer layer = new MapLayer();
    layer.Add(relay);
    myMap.Layers.Add(layer); // myMap is the name of your map control 
