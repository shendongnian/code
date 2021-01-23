    public class ProductsController : Controller {
        private IProductsDataService _service;
        public ProductsController(IProductsDataService service) {
            _service = service;
        }
        protected override void Dispose(bool disposing) {
            _service.Dispose();
            base.Dispose(disposing);
        }
        // Or whatever you're using it as.
        [HttpPost]
        public ActionResult AddProduct(ProductEntity product) {
            var newProduct = _service.AddProduct(product);
            return View(newProduct);
        }
    }
