    public class RepositoryRoute : Route
    {
        public RepositoryRoute(string name, string url, object defaults)
            : base(url, new RouteValueDictionary(defaults), new MvcRouteHandler())
        {
            string moduleUrl = url.Replace(
                REPOSITORY_PARAMETER, REPOSITORY_PARAMETER + MODULE_PARAMETER);
            mModuleRoute = new Route(
                moduleUrl, new RouteValueDictionary(defaults), new MvcRouteHandler());
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData rd = mModuleRoute.GetRouteData(httpContext);
            if (rd == null)
                return base.GetRouteData(httpContext);
            if (!rd.Values.ContainsKey(MODULE))
                return rd;
            // set repository as repo/submodule format
            // if a submodule is present in the URL
            string repository = string.Format("{0}/{1}",
                rd.Values[REPOSITORY],
                rd.Values[MODULE]);
            rd.Values.Remove(MODULE);
            rd.Values[REPOSITORY] = repository;
            return rd;
        }
        Route mModuleRoute;
        const string REPOSITORY = "repository";
        const string MODULE = "module";
        const string REPOSITORY_PARAMETER = "{" + REPOSITORY + "}/"; // {repository}/
        const string MODULE_PARAMETER = "{" + MODULE + "}/"; // {module}/
    }
