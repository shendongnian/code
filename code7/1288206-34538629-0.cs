    [HttpGet]
    public ActionResult Disable(string id)
    {
        Role rol = new UserRepository().GetRole("Disabled");             
        new UserRepository().UpdateUser(id,rol.RoleId);
        return RedirectToAction("Users");
    }
