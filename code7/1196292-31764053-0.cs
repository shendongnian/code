            //Update the Map
            private void atualizarMapa()
            {
                //Clean the map
                gMapControl1.Overlays.Clear();
    
                //Create a new overlay 
                GMapOverlay markersOverlay = new GMapOverlay("markers");
    
                foreach (PointLatLng p in Pontos)
                {
    
                    //Create a red marker
                    GMarkerGoogle marker1 = new GMarkerGoogle(p, GMarkerGoogleType.red);
                    
                    //Add a marker on the overlay
                    markersOverlay.Markers.Add(marker1);
                }
                
                //Add the overlay on the gMapControl1(Map)
                gMapControl1.Overlays.Add(markersOverlay);
    
                double zoomAtual = gMapControl1.Zoom;
                gMapControl1.Zoom = zoomAtual + 1;
                gMapControl1.Zoom = zoomAtual;
    
            }
