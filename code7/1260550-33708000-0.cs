    [HttpPost]
    public void Start([FromBody]string value)
    {
        CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
        ...
    }
    
    [HttpPost]
    public void Login([FromBody]string value)
    {
        CookieHeaderValue cookie = Request.Headers.GetCookies("user").FirstOrDefault();
        ...
    }
