    public void pushPin(Microsoft.Phone.Maps.Controls.Map map, GeoCoordinate position)
    {
        map.Center = position;
        map.ZoomLevel = 9;
        TextBlock tb = new TextBlock();
        tb.FontFamily = new FontFamily("/fontello.ttf#fontello");
        tb.Text = "\uE800";
        var mapOverLay = new MapOverlay();
        mapOverLay.Content = tb;
        mapOverLay.GeoCoordinate = position;
        var mapLayer = new MapLayer();
        mapLayer.Add(mapOverLay);
        map.Layers.Add(mapLayer);  
    }
