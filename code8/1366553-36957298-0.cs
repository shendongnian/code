    void ReadMapTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        GeoCoordinate tapLocation = 
             distanceMap.ConvertViewportPointToGeoCoordinate(e.GetPosition((UIElement)sender));
    }
