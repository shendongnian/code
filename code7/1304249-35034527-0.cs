    private async Task SearchNearbyIncidents(Geopoint location)
    {
        IList<Geopoint> geoPoints = await bingMapRestService.GetIncidents(MapUtil.GetBoundingBox(location.Position, 5), ConstantValues.BingMapKey);
        foreach (var geoPoint in geoPoints)
        {
            MapIcon mapIcon = new MapIcon
            {
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/TrafficYield.png")),
                Location = geoPoint,
                NormalizedAnchorPoint = new Point(0.5, 0.5),
                Title = "Incidents"
            };
            mapControl.MapElements.Add(mapIcon);
        }
    }
