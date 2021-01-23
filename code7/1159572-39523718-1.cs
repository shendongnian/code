    GMapOverlay markersOverlay = new GMapOverlay("markers"); 
    
    private void gmap_MouseClick(object sender, MouseEventArgs e)
     {
    
          if (e.Button == System.Windows.Forms.MouseButtons.Left)
          {
              double lat = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
              double lng = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
    
              // GMapOverlay markerOverlay = new GMapOverlay("markers"); Your code here
    
              GMarkerGoogle marker = new GMarkerGoogle(new  
                                   GMap.NET.PointLatLng(lat, lng), 
                                   GMarkerGoogleType.green_pushpin);
    
              markerOverlay.Markers.Add(marker);
              gmap.Overlays.Add(markerOverlay);
          }
    }
