    [EnableQuery]
    public IHttpActionResult GetProduct([FromODataUri] int key)
    {
        return Ok(Proxy.Products.FirstOrDefault(c => c.ID == key));
    }
    [EnableQuery]
    public IHttpActionResult GetCategory([FromODataUri] int key)
    {
        return Ok(Proxy.Products.FirstOrDefault(c => c.ID == key));
    }
