    //your routeconfig will be
    routes.MapRoute(
      name: "default",
      url: "{controller}/{file}",
      defaults: new { controller = "OrderForm", action = "Index", file = "" }
    );
    //here no need to have 40 routing table one is enough
    //your controller/action will be
    public class OrderForm
    {
      public ActionResult  Index(string file)
      {
        ViewBag.Orderform=file
        return View(file);
      }
        }
    //view bag variable is accessible in view as well as in javascript
