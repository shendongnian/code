    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var p1 = new Product { ID = 1, Description = "Product 1" };
            var p2 = new Product { ID = 2, Description = "Product 2" };
            return View(new List<Product> { p1, p2 });
        }
        public PartialViewResult GetDetails(string description)
        {
            return PartialView("_GetDetails", description);
        }
    }
