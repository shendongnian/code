    private MapLayer _MapLayer;
    private Pushpin _Pushpin;
    private MapOverlay _MapOverlay;
    void InitialDraw()
    {
        MapLayer _MapLayer = new MapLayer(); 
        Pushpin _Pushpin = new Pushpin();
        _Pushpin.GeoCoordinate = myGeoCoordinate;
        _Pushpin.Tag = "myLocation";
        _Pushpin.Content = "My car"; 
        MapOverlay _MapOverlay = new MapOverlay(); 
        _MapOverlay.Content = _Pushpin;
        _MapOverlay.GeoCoordinate = myGeoCoordinate; 
        _MapLayer.Add(_MapOverlay); 
        MyMap.Layers.Add(_MapLayer);
    }
    void DrawMyLocationOverLay()
    {
        _Pushpin.GeoCoordinate = myGeoCoordinate;
        _MapOverlay.GeoCoordinate = myGeoCoordinate;
    }
