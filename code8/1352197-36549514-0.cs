    // GET api/Products
    [HttpGet]
    [ResponseType(IEnumerable<Product>)]
    public IHttpActionResult GetProducts()
    {
        Ok(return db.Products);
    }
