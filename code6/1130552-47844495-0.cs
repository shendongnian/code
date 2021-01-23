    /// <summary>
    /// Allows you to create or extend a collection of route values to use in a url action
    /// </summary>
    public class RouteValueBuilder
    {
        readonly RouteValueDictionary routeValues;
        private int gridFilterCounter = 0;
        public RouteValueBuilder(object existingRouteValues = null)
        {
            routeValues = existingRouteValues as RouteValueDictionary ?? new RouteValueDictionary(existingRouteValues);
        }
        public void Add(string field, object value)
        {
            if (field == "grid_filter" && routeValues.ContainsKey(field))
            {
                // Because we can't add duplicate keys and GridMvc doesn't support joined comma format for query strings,
                // we briefly rename each new filter, and then the Finalise method must be called after the url
                // string is rendered to restore the grid_filter names back to normal.
                gridFilterCounter++;
                routeValues.Add(field + gridFilterCounter, value);
            }
            else if (routeValues.ContainsKey(field))
            {
                // Since duplicate key names are not supported, the concatenated comma approach can be used
                routeValues[field] += "," + value;
            }
            else
            {
                routeValues.Add(field, value);
            }
        }
        public RouteValueDictionary Get()
        {
            return routeValues;
        }
        /// <summary>
        /// Cleans up the final string url, fixing workarounds done during the building process.
        /// This must be called after the final url string is rendered.
        /// </summary>
        public static string Finalise(string url)
        {
            // Restores grid_filter parameters to their correct naming.  See comments on Add method.
            for (var i = 0; i < 100; i++)
            {
                url = url.Replace("grid_filter" + i, "grid_filter");
            }
            return url;
        }
    }
