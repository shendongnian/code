    BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.643, Longitude = -122.131 };
    Geopoint snPoint = new Geopoint(snPosition);
    Grid MyGrid = new Grid();
    MyGrid.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
    TextBlock text = new TextBlock();
    text.Text = "Hello";
    text.Width = 200;
    MyGrid.Children.Add(text);
    MyMapControl.Center = snPoint;
    MyMapControl.ZoomLevel = 14;
    // Get the address from a `Geopoint` location.
    MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(snPoint);
    
    if (result.Status == MapLocationFinderStatus.Success)
    {
        text.Text = "Street = " + result.Locations[0].Address.Street;
    }
    MyMapControl.Children.Add(MyGrid);
    MapControl.SetLocation(MyGrid, snPoint);
    MapControl.SetNormalizedAnchorPoint(MyGrid, new Point(0.5, 0.5));
