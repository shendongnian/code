    private void MapControl1_MapElementClick(MapControl sender, MapElementClickEventArgs args)
    {
        foreach (var e in args.MapElements)
        {
            if (e is MapPolygon)
            {
                var poly = e as MapPolygon;
                //Is MapPolygon
            }
            else if (e is MapPolyline)
            {
                var poly = e as MapPolyline;
                //Is MapPolyline
            }
            else if (e is MapIcon)
            {
                var icon = e as MapIcon;
                //Is MapIcon
            }
        }
    }
