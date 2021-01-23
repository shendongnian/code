    MapLayer layer1 = new MapLayer();
    Pushpin pushpin1 = new Pushpin();
    pushpin1.GeoCoordinate = MyGeoPosition;
    pushpin1.Content = "Content";
    MapOverlay overlay1 = new MapOverlay();
    overlay1.Content = pushpin1;
    overlay1.GeoCoordinate = MyGeoPosition;
    layer1.Add(overlay1);
    myMap.Layers.Add(layer1);
