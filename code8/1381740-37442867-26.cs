    public class CategoryController : Controller
    {
        private readonly IQueryProcessor queryProcessor;
        public CategoryController(IQueryProcessor queryProcessor)
        {
            if (queryProcessor == null)
                throw new ArgumentNullException("queryProcessor");
            this.queryProcessor = queryProcessor;
        }
        public ActionResult Index(int id)
        {
            var categoryDetails = this.queryProcessor.Execute(new GetCategoryDetailsQuery
            {
                CategoryId = id
            });
            return View(categoryDetails);
        }
	}
    public class ProductController : Controller
    {
        private readonly IQueryProcessor queryProcessor;
        public ProductController(IQueryProcessor queryProcessor)
        {
            if (queryProcessor == null)
                throw new ArgumentNullException("queryProcessor");
            this.queryProcessor = queryProcessor;
        }
        public ActionResult Index(int id)
        {
            var productDetails = this.queryProcessor.Execute(new GetProductDetailsDataQuery
            {
                ProductId = id
            });
            return View(productDetails);
        }
	}
