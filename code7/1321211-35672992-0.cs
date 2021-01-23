    [HandleException(typeof(InvalidOperationException), HttpStatusCode.Found, ResponseContent = "Custom message 12")]
    public IHttpActionResult GetHandleException(int num)
    {
        switch (num)
        {
            case 12: return Redirect("Your Uri Here");
            default: throw new Exception("base exception");
        }
    }
