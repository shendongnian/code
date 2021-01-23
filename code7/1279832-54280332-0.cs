            GMap.NET.WindowsForms.GMapMarker marker =
    new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
        new GMap.NET.PointLatLng(33.626057, 73.071442),
        GMap.NET.WindowsForms.Markers.GMarkerGoogleType.lightblue);
            markersOverlay.Markers.Add(addmark1);
           markersOverlay.Markers.Add(marker);
           gMapControl1.Overlays.Add(mark);
           
          // gMapControl1.Overlays.Clear();
            gMapControl1.MarkersEnabled = true;
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Refresh();
           // gMapControl1.
            gMapControl1.Position = new PointLatLng(33.626057, 73.071442);
