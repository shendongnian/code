    public async Task<IHttpActionResult> SendAsync()
    {    
        // Object passed to Ok will be automatically serialized to JSON
        // if response content type is JSON (and, by default, this is the serialization
        // format in ASP.NET WebAPI)
        return Ok(new { text = "hello world" });
    }
