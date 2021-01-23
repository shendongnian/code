    [Route("valueparam/{value}"), HttpGet]
    public void PostWithParam([FromUri]string value)
    {
    }
    result = client.GetAsync(baseAddress + "api/valueparam/1").Result;
