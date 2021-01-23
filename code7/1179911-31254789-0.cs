    public HttpResponseMessage GetProducts(int id)
    {
        var prods = GetProductsByReportId(id);
        if (prods.Count == 0)             
           return Request.CreateResponse(HttpStatusCode.NotFound);
        else
            return Request.CreateResponse(HttpStatusCode.OK, prods);
    }
