    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            // Create your model (this could be anything...)
            var model = new List<ProductViewModel>
            {
                new ProductViewModel { Name = "Apple", Description = "A red apple" },
                new ProductViewModel { Name = "Orange", Description = "An orange orange" }
            };
            
            // Return the main view and your model
            return View("ListProducts", model);
        }    
    }
