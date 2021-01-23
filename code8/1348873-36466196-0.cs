    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(User model)
    {
        if(ModelState.IsValid)
        {
            // do stuff
        }
        return RedirectToAction("Index", "Announcements");
    }
