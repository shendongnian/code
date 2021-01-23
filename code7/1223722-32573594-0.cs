    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "LoadMain", id = UrlParameter.Optional }
        );
    }
    public class HomeController : Controller
    {
        public ActionResult LoadMain()
        {
            return View("Main.cshtml");
        }
    }
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return PartialView("Index.cshtml");
        }
    }
