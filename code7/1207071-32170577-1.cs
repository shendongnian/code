    [Authorize]
    public ActionResult MySecretAction()
    {
        // all authorized users could use this method don't matter how has been authenticated
        // we have access current user principal by calling also
        // HttpContext.User
    }
    [Authorize(Roles="TempUser")]
    public ActionResult MySecretAction()
    {
        // just temp users have accesses to this method
    }
