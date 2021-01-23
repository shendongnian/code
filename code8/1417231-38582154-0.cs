        private ProductTestInformation _productTestInformation;
        public ProductLog(ProductTestInformation productTestInformation)
        {
            _productTestInformation = productTestInformation;
        }
        public int? ProductId { get { return _productTestInformation.ProductId; } set { _productTestInformation.ProductId = value; } }
        public string ProductName { get { return _productTestInformation.ProductName; } set { _productTestInformation.ProductName = value; } }
    }
    public class ProductTestInformation 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
    public class ProductController : Controller
    {
        public ActionResult View() 
        {
            var productTestInfo = new ProductTestInformation();// or get from the db
            var productlog = new ProductLog(productTestInfo);
            return View();
        }
    }
