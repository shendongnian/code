    public interface IRouteInspector {
        bool RequestIsInRoutes();
    }
    public class RouteInspector : IRouteInspector {
        private RouteCollection routes;
        private HttpContextBase contextBase;
        public RouteInspector(RouteCollection routes, HttpContextBase contextBase) {
            this.routes = routes;
            this.contextBase = contextBase;
        }
        public bool RequestIsInRoutes() {
            if (routes.GetRouteData(contextBase) != null) {
                //Route exists
                return true;
            }
            return false;
        }
    }
