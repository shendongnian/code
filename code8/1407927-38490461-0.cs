    [RouteArea("ProductReuse")]
    [Route("ProductReuse")]
    public partial class ProductReuseController : BaseProductReuseController
    {
        [HttpGet]
        [Route("Index")]
        [Route("")]  // Use an empty name to set the default page...
        public ActionResult Index()
        {
            if (SessionUserLogin == null) return LoginActionResult(SessionAppName);
    
            var serviceResponse = _productReuseService.IndexQuery(SessionUserId);
            var response = _mapper.Map<IndexViewModel>(serviceResponse);
    
            return View(response);
        }
        ...
    }
