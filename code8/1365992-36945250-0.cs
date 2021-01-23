    [HttpPost]
    [Route("api/products/{clinicId}")]
    
    public IHttpActionResult InsertNewProductTotal(int clinicId,[FromBody]Product[]) // << HOW CAN I GET THE ARRAY OF OBJECTS HERE ??? >>
    {
        var newAttorney = _productSaleLogic.InsertNewProductTotal(clinicId, productsList);
        return Created(Request.RequestUri.ToString(), newAttorney);
    }
