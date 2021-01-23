<system.web>
   <customErrors mode="On" defaultRedirect="~/Error/" redirectMode="ResponseRedirect">
      <error statusCode="404" redirect="~/Error/Error404/" />
	  <error statusCode="500" redirect="~/Error/Error500/" />
	  <error statusCode="400" redirect="~/Error/Error400/" />
   </customErrors>
</system.web>
Then you have to configure your `RouteConfig.cs` :
routes.MapRoute(
    name: "Default",
    url: "{controller}/{action}/{id}",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
);
routes.MapRoute(
    "404-PageNotFound",
    "{*url}",
    new { controller = "Error", action = "Error404" }
);
And finally, you have to create your custom error `View` and `Action` :
public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Error404()
        {
            return View();
        }
        public ViewResult Error500()
        {
            return View();
        }
        public ViewResult Error400()
        {
            return View();
        }
        public ActionResult General()
        {
            return View();
        }
    }
