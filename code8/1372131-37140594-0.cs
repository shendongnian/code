     RoutingProvider rp = gmap1.MapProvider as RoutingProvider;
     if (rp == null)
     {
                rp = GMapProviders.OpenStreetMap; // use OpenStreetMap if provider does not implement routing
     }
     MapRoute route = rp.GetRoute(start, end, false, false, 15);
     if (route != null)
     {
                GMapRoute mRoute = new GMapRoute(route.Points);
                {
                    mRoute.ZIndex = -1;
                }
                
                gmap1.Markers.Add(mRoute);
                gmap1.ZoomAndCenterMarkers(null);
     }
     else
     {
                System.Diagnostics.Debug.WriteLine("There is no route");
     }
