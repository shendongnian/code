    public class PathFinder
    {
        public IEnumerable<string> FindRoutes(Route[] routes, string start, string end, int max_length)
        {
            if (max_length == 0)
                yield break;
            if (start == end)
            {
                yield return start;
                yield break;
            }
            if (max_length == 1)
                yield break;
            
            foreach (var route in routes.Where(x => x.From == start))
            {
                IEnumerable<string> sub_routes = FindRoutes(routes, route.To, end, max_length - 1);
                foreach (string sub_route in sub_routes)
                {
                    yield return start + sub_route;
                }
            }
        }
    }
