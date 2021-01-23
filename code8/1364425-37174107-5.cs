    public interface IRouteInspector {
        bool RequestIsInRoutes();
    }
    public interface IHttpContextAccessor {
        HttpContextBase HttpContext { get; }
    }
    public interface IRouteTable {
        RouteCollection Routes { get; }
    }
    public class RouteInspector : IRouteInspector {
        private IRouteTable routeTable;
        private IHttpContextAccessor contextBase;
        public RouteInspector(IRouteTable routeTable, IHttpContextAccessor contextBase) {
            this.routeTable = routeTable;
            this.contextBase = contextBase;
        }
        public bool RequestIsInRoutes() {
            if (routeTable.Routes.GetRouteData(contextBase.HttpContext) != null) {
                //Route exists
                return true;
            }
            return false;
        }
    }
