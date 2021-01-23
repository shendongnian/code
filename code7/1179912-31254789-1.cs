    [HttpGet]
    public HttpResponseMessage GetProducts(int id)
    {
        var prods = GetProductsByReportId(id);
        if (prods == null)             
           return Request.CreateResponse(HttpStatusCode.NotFound);
        else
            return Request.CreateResponse(HttpStatusCode.OK, prods);
    }
