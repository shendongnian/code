        private void atualizarMapa()
        {
            //Clean the map
            gMapControl1.Overlays.Clear();
            //Create a new overlay 
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            //Add the overlay on the gMapControl1(Map)
            // This makes all the difference: The marker is set in the correct position, if the overlay is added first.
            gMapControl1.Overlays.Add(markersOverlay);
            foreach (PointLatLng p in Pontos)
            {
                //Create a red marker
                GMarkerGoogle marker1 = new GMarkerGoogle(p, GMarkerGoogleType.red);
                //Add a marker on the overlay
                markersOverlay.Markers.Add(marker1);
            }
            //gMapControl1.UpdateMarkerLocalPosition(marker);
        }
