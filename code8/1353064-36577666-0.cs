    [Route("api/Accounts/{accountNumber}/GetCustomerId")]
    [AllowAnonymous]
    [OverrideAuthorization]
    [HttpGet]
    public HttpResponseMessage GetCustomerId(string accountNumber)
    {
        // Process     
        // ..
        // ..
    }
