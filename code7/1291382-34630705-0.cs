    public IHttpActionResult GetProduct(string id = "")
    {
        var product = products.FirstOrDefault((p) => p.Id == id);
        return Ok(product);
    }
