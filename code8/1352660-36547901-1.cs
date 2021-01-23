    [HttpGet, Route("api/someroute")]
    public async Task<IHttpActionResult> YourMethod(string fields = null)
    {
        try
        {
             var products = await yourRepo.GetProductsList();
    
             if (fields.HasValue())
             {
                  return Ok(products.ToDataShape(fields, PropertyFormat.CamelCase));
             }
    
             return Ok(products);
         }
         catch (Exception)
         {
             return InternalServerError();
         }
    }
