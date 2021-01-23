    [Authorize(Policy = "Product")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        [Authorize(Policy = "ProductEdit")]
        public IActionResult Edit()
        {
            return View();
        }
    }
