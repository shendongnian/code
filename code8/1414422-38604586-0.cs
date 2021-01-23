    public class ProductsController : ApiController 
    {
        [HttpPut, Route("/api/Products/{productId:int}")]
        public void UpdateProduct(UpdateProductModel model) 
        {
             if (ModelState.IsValid)
             {
                //
             }
             else
             {
                BadRequest();
             }
        }
    }
