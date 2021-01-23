    foreach (var cor in CoOrdinates)
     {
       MapOverlay myLocOverlay = new MapOverlay();
       myLocOverlay.PositionOrigin = new Point(0.5, 0.5);
       myLocOverlay.GeoCoordinate = new GeoCoordinate();
       myLocOverlay.GeoCoordinate.Latitude = cor.Coordinates.Longitude;
       myLocOverlay.GeoCoordinate.Longitude = cor.Coordinates.Latitude;
       myLocOverlay.Content = CreateShape(myLocOverlay.GeoCoordinate.Latitude, myLocOverlay.GeoCoordinate.Longitude);
       // Create a MapLayer to contain the MapOverlay.
       MapLayer myLocLayer = new MapLayer();
       myLocLayer.Add(myLocOverlay);
       // Add the MapLayer to the Map.
        mapWithMyLocation.Layers.Add(myLocLayer);
     }
    private Polygon CreateShape(double latitude, double longitude)
        {
            Polygon MyPolygon = new Polygon();
            MyPolygon.Points.Add(new Point(4, 0));
            MyPolygon.Points.Add(new Point(22, 0));
            MyPolygon.Points.Add(new Point(4, 60));
            MyPolygon.Stroke = new SolidColorBrush(Colors.Red);
            MyPolygon.Fill = new SolidColorBrush(Colors.Green);
            MyPolygon.SetValue(Grid.RowProperty, 1);
            MyPolygon.SetValue(Grid.ColumnProperty, 0);
            MyPolygon.Tag = new GeoCoordinate(latitude, longitude);
            MyPolygon.Tap += MyPolygon_Tap;
            return MyPolygon;
        }
