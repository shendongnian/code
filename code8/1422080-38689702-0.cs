        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                name: "Services",
                url: "api/store/{id}/services/{prop}",
                defaults: new { controller = "Services", action = "store", prop = UrlParameter.Optional }
            );
    
            routes.MapRoute(
                name: "Store",
                url: "store/{id}",
                defaults: new { controller = "Store", id = UrlParameter.Optional}
            );
        }
    namespace APITestter1.Controllers
    {
        public class ServicesController : ApiController
        {
            [HttpGet, ActionName="store"]
            public string Get(int id, string prop = "xxx")
            {
                return "Hello services World!" + id + " added attribute " + prop;
            }
            [HttpPost, ActionName="store"]
            public string Post(int id, string prop = "xxx")
            {
                return "Hello Post World!" + id + " added attribute " + prop;
            }
    
        }
    }
