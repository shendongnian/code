    [HttpGet, Route("apples")]
    public HttpResponseMessage GetApples()
    {
        return _productRepository.Get(id);
    }
     
    [HttpGet, Route("apples")]
    pblic HttpResponseMessage GetApples([FromUri]string foo)
    {
        return new DumpTruck(); // Say WHAAAAAAT?!
    }
