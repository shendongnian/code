    public IHttpActionResult Get (int id)
    {
        Product product = _repository.Get (id);
        if (product == null)
        {
            var response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "");
            response.ReasonPhrase = "Product Not Found";
            return response;
        }
        return Ok(product);  // Returns an OkNegotiatedContentResult
    }
