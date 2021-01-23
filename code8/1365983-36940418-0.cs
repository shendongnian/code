    public IHttpActionResult InsertNewProductTotal(int clinicId, [HttpPost] Product[] productsList)
    {
        var newAttorney = _productSaleLogic.InsertNewProductTotal(clinicId, productsList);
        return Created(Request.RequestUri.ToString(), newAttorney);
    }
