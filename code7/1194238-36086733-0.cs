            PointLatLng startp = new PointLatLng(-25.974134, 32.593042);
            PointLatLng endp = new PointLatLng(-25.959048, 32.592827);
            MapRoute route = BingMapProvider.Instance.GetRoute(startp, endp, false, false, 15);
            GMapRoute r = new GMapRoute(route.Points,"Myroutes");
            GMapOverlay routesOverlay = new GMapOverlay("Myroutes");
            routesOverlay.Routes.Add(r);
            gmap.Overlays.Add(routesOverlay);
            r.Stroke.Width = 2;
            r.Stroke.Color = Color.SeaGreen; 
