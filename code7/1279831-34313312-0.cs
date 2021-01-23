    private void AddOrUpdateMarker(string tag, double lat, double lng)
    {
         // assuming "markersOverlay" is a field
         var marker = markersOverlay.Markers.FirstOrDefault(m => m.Tag == tag);
    
         if (marker == null)
         {
              marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.green);
              marker.Tag = tag;
              markersOverlay.Markers.Add(marker);
         }
    
         // update the position
         marker.Position = new PointLatLng(lat, lng);
    }
