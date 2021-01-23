    public static class WebApiExtensions
    {
        public static IDictionary<string, object> GetWebApiRoutes(this RouteData routeData)
        {
            if (!routeData.Values.ContainsKey("MS_SubRoutes"))
                return new Dictionary<string,object>();
            return ((IHttpRouteData[])routeData.Values["MS_SubRoutes"]).SelectMany(x => x.Values).ToDictionary(x => x.Key, y => y.Value);
        }
    }
