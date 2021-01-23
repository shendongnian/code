    [Authorize]
    public ActionResult MySecretAction()
    {
        // all authorized users can use this method
        // we have access current user principal by calling also
        // HttpContext.User
    }
    [Authorize(Roles="Admin")]
    public ActionResult MySecretAction()
    {
        // just Admin users have access to this method
    } 
