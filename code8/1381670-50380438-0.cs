    [HttpGet("tunnel")]
    public ContentResult Tunnel() {
        var response = HttpContext.Response;
        response.StatusCode = (int) HttpStatusCode.OK;
        response.Headers[HeaderNames.CacheControl] = CacheControlHeaderValue.NoCacheString;
        return ContentResult("blablabla", "text/plain", Encoding.UTF8);
    }
