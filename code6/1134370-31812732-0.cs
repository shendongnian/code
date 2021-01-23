        GeoCoordinate myPosition = null;
        MapRoute MyMapRoute = null;
        RouteQuery route = null;
        private void getRouteTo(GeoCoordinate myPosition, GeoCoordinate destination)
        {
            if (MyMapRoute != null)
            {
                map.RemoveRoute(MyMapRoute);
                MyMapRoute = null;
                route = null;
            }
            route = new RouteQuery()
            {
                TravelMode = TravelMode.Driving,
                Waypoints = new List<GeoCoordinate>()
                {
                    myPosition, 
                    destination
                },
                RouteOptimization = RouteOptimization.MinimizeTime
            };
            route.QueryCompleted += routeQuery_QueryCompleted;
            route.QueryAsync();
        }
        void routeQuery_QueryCompleted(object sender, QueryCompletedEventArgs<Route> e)
        {
            if (e.Error == null)
            {
                Route MyRoute = e.Result;
                
                MyMapRoute = new MapRoute(MyRoute);
                map.AddRoute(MyMapRoute);
                route.Dispose();
            }
        }
