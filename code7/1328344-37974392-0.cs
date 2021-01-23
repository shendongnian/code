    BasicGeoposition geoPosition = new BasicGeoposition();
    geoPosition.Latitude = 27.175015;
    geoPosition.Longitude = 78.042155;
    // get position
    Geopoint myPoint = new Geopoint(geoPosition);
    //create POI
    MapIcon myPOI = new MapIcon { Location = myPoint, Title = "My Position", NormalizedAnchorPoint = new Point(0.5, 1.0), ZIndex = 0 };
    // Display an image of a MapIcon
    myPOI.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pin.png"));
    // add to map and center it
    MyMap.MapElements.Add(myPOI);
    MyMap.Center = myPoint;
    MyMap.ZoomLevel = 10;
    
    MapScene mapScene = MapScene.CreateFromLocationAndRadius(new Geopoint(geoPosition), 500, 150, 70);
    await MyMap.TrySetSceneAsync(mapScene);
