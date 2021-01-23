    [HttpGet]
    public Task Get()
    {
        HttpContext.Response.ContentType = "text/event-stream";
        var sourceStream = // get the source stream
        return sourceStream.CopyToAsync(HttpContext.Response.Body);
    }
