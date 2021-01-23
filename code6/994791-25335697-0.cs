    public IHttpActionResult PutProduct(int id, Product product)
    {
         product.Price = 5;
         return StatusCode(HttpStatusCode.NoContent);     
    }
