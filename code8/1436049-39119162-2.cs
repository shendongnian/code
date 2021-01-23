    [Route("api/categories/{categoryIds}/products")]
    public HttpResponseMessage GetProducts([ModelBinder(typeof(CategoryIdsModelBinder))] CategoryIds categoryIds)
    {
        // <2> Get products using categoryIds.Ids
    }
