    Bitmap flag = new Bitmap(50, 50);
    gmap.MapProvider = GMap.NET.MapProviders.BingHybridMapProvider.Instance;
    GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
    Graphics fg = Graphics.FromImage(flag);
    fg.FillRectangle(Brushes.Red, 100, 100, 50, 50);
    GMapOverlay markerOverlay = new GMapOverlay(NametextBox.Text);
    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(-25.966688, 32.580528),flag);
    marker.Offset = new Point(-flag.Width/2, -flag.Height/2);  // Set point to middle of bitmap
    markerOverlay.Markers.Add(marker);
    gmap.Overlays.Add(markerOverlay);
