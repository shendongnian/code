    [HttpPost]
    public IHttpActionResult Test()
    {
    // Get URL Args for example is 
    var args = Request.RequestUri.Query;
    // But if the arguments are in the body i don't have idea.
    }
