    [Route("Test2")]
    [HttpPost]
    public IHttpActionResult Test2()
    {
       IEnumerable<string> headerValues=request.Headers.GetValues("MyCustomID");
       var guid = headerValues.FirstOrDefault();
       return Ok();
    }
