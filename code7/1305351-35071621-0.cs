    public class ProductsController : ApiController
        {
            public HttpResponseMessage Post(Product product)
            {
                if (ModelState.IsValid)
                {
                    // Do something with the product (not shown).
    
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
        }
