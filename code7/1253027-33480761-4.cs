    [HttpPost]
    public ActionResult Edit(EditUserVM model)
    {
       var existingUser = GetUserFromYourDb(model.UserId);
       
       existingUser.Name = model.Name;
       existingUser.Email = model.Email;
       SaveUser(existingUser);
       return RedirectToAction("UserSaved");
    }
