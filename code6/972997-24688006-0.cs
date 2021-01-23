    [HttpPost]
    [ODataRoute("RegisterNewUser")]
    public IHttpActionResult InitializeUser(ODataActionParameters parameters)
    {
        // code to save user to DB & initialize account information...
        return Ok<User>(new User());
    }
