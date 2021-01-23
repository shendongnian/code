    [Route("api/accounts/{accountNumber}/GetX")]
    [AllowAnonymous]
    [OverrideAuthorization]
    [HttpGet]
    public HttpResponseMessage GetX(string accountNumber)
    {
        // Process     
        // ..
        // ..
    }
