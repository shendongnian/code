    [HttpGet]
    public IHttpActionResult Foo()
    {
        try 
        {
            int foo = 1;
            return Ok(foo);
        }
        catch(Exception exception)
        {
            // log exception or whatever you need to do
            return InternalServerError(exception);
        }
    }
