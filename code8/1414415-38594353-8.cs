    public class ProductsController : ApiController {
        [HttpPost, Route("api/Products/{productId:int}")]
        public IHttpActionResult UpdateProduct(int productId, UpdateProductModel model) {
            if (model == null) return NotFound();
            if (model.ProductId != productId) return NotFound();
            return Ok();
        }
    }
