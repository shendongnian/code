    namespace YourApp.Web.ApiControllers
    {
        [AllowAnonymous]
        public class ProductsController : ApiController
        {
            [HttpGet]
            public HttpResponseMessage Products()
            {
                  var result = new ProductResult();//you could also use the view class ProductsListView
                  result.Products = _repository.GetProducts();
                  return Request.CreateResponse(httpStatusCode, result);
            }
        }
    }
