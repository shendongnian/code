    public IHttpActionResult Foo()
    {
        var bar = new Bar { Message = "Hello" };
        return Request.CreateResponse(HttpStatusCode.OK, bar, new MediaTypeHeaderValue("application/json"));
    }
