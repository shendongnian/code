    public ActionResult Register(RegisterModel user)
    {
        if (ModelState.IsValid)
        {
            // To check if username already exist
            var searchUserName = db.RegisterTables.Where(x => x.tUserName.Equals(user.UserName)).FirstOrDefault();
    
            if (searchUserName == null)
            {
                var dbUser = user.Map();
    
                db.RegisterTables.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Login");
            }
            else ModelState.AddModelError("", "User is already Registred.");
        }
    
        return View(user);
    }
