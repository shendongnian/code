    public ActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            User saveUser = new User { ID = user.ID }
            db.Attach(saveUser);
            saveUser.FirstName = user.FirstName
            saveUser.LastName = user.LastName
            saveUser.EmailAddress = user.EmailAddress;
            saveUser.Company = user.Company;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(user);
    }
