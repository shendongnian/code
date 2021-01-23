    public class RouteFinder
    {
        public IEnumerable<string> FindRoutes(NodeLink[] node_links, string start, string end, int max_length)
        {
            if (max_length == 0)
                yield break;
            if (start == end)
            {
                yield return start;
                yield break;
            }
            if (max_length == 1)
            {
                yield break;
            }
            foreach (var route in node_links.Where(x => x.From == start))
            {
                IEnumerable<string> sub_routes = FindRoutes(node_links, route.To, end, max_length - 1);
                foreach (string sub_route in sub_routes)
                {
                    yield return start + sub_route;
                }
            }
        }
    }
