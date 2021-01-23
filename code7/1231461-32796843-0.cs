                private List<string> GetRouteMap(string start, int max)
        {
            var startNode = GetNode(start);
            List<string> selectedRoutes = new List<string>();
            //safety check
            if(max == 0)
            {
                selectedRoutes.Add(start.ToString());
                return selectedRoutes;
            }
            Edge[] possibleRoutes = GetRoutes(startNode);
            foreach(Edge edge in possibleRoutes)
            {
                //recursive call until max==0
                List<string> routeMap= GetRouteMap(edge.To.Name, max - 1, exact);
                foreach(string route in routeMap)
                {
                    selectedRoutes.Add(startNode.Name + route);
                }
            }
            return selectedRoutes;
        }
