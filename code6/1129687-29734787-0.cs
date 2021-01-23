    public class HomeController : Controller
    {
        public ActionResult Product()
        {
            var product = // Logic to populate product from database.
            
            return product != null ? View() 
                : RedirectToAction("OtherAction" 
                               /*, "OptionalControllerName" */ 
                               /*, new { optionalParam = xx } */ 
                                  )
        }
        public ActionResult OtherAction()
        {
            return View();
        }
    }
