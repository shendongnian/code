    public ActionResult Register(int ID)
    {
        var model = new RegisterModel();
        model.AvatarID = ID;
        return View(model);
    }
