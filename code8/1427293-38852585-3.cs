    public static class WebApiExtensions
    {
        public static object GetWebApiRouteData(this RouteData routeData, string key)
        {
            if (!routeData.Values.ContainsKey("MS_SubRoutes"))
                return null;
            object result = ((IHttpRouteData[]) routeData.Values["MS_SubRoutes"]).SelectMany(x => x.Values)
                .Where(x => x.Key == key).Select(x => x.Value).FirstOrDefault();
            return result;
        }
    }
