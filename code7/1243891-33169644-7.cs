    public IHttpActionResult Foo()
    {
        var bar = new Bar { Message = "Hello" };
        return Content(HttpStatusCode.OK, bar, new JsonMediaTypeFormatter(), new MediaTypeHeaderValue("application/json"));
    }
