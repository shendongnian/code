    namespace myApp.Controllers
    {
        public class ProductController : Controller
        {
            private readonly MyHelper myHelper;
    
            public ProductController(MyHelper myHelper)
            {
                this.myHelper = myHelper;
            }
    
            [HttpGet]
            public async Task<ActionResult> Index(int productId)
            {
                var productVM = await myHelper.GetProductAsync(productId);
                return View(productVM);
            }
        }
    }
