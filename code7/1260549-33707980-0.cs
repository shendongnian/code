    [Route("start")]
    public void PostStart([FromBody]string value)
    {
        CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
        ...
    }
    [Route("login")]
    public void PostLogin([FromBody]string value)
    {
        CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
        ...
    }
