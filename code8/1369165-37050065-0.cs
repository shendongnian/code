    [HttpPost]
    public async Task<ActionResult> Mobilelogin(LoginViewModel model)
    {
        var user = await UserManager.FindAsync(model.Email, model.Password);
        if (user != null)
        {
            return new HttpStatusCodeResult(201); // user found
        }
        else
        {
            return new HttpStatusCodeResult(401); // user not found
        }
    }
