    [HttpPost]
    public HttpResponseMessage SomeMethod()
    {
        // Do things
        return Request.CreateResponse(HttpStatusCode.NoContent);
    } 
