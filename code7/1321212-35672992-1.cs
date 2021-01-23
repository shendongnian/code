    [HandleException(typeof(InvalidOperationException), HttpStatusCode.Found, ResponseContent = "Custom message 12")]
    public IHttpActionResult GetHandleException(int num)
    {
        switch (num)
        {
            case 12: return Content(HttpStatusCode.Redirect, new InvalidOperationException("your message here"));
            default: throw new Exception("base exception");
        }
    }
