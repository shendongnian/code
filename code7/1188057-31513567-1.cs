    [AllowAnonymous]
    public ActionResult Register()
    {
        RegisterViewModel model = new RegisterViewModel();
        //Controller should not intervene with presentation logic
        //so SelectList is not used here
        model.Roles = context.Roles.ToList();
        return View(model);
    }
