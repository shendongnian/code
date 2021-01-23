    //your route table will be
     routes.MapRoute(
          name: "default",
          url: "{controller}/{file}",
          defaults: new { controller = "OrderForm", action = "Index"}
        );
    //your controller will be
     public class OrderForm
        {
          public ActionResult  Index()
          {
            return View(file);
          }
