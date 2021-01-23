    [Route("")]
    [HttpGet]
    public async Task<HttpResponseMessage> Get([FromUri] SomeEnum? param = null)
    {
        //...
    }
