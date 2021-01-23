    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UserVM model)
    {
        // Return early
        if (!ModelState.IsValid)
        {
            // You will enter this automatically of UserID is null
            model.DepartmentList = ... // assign the SelectList
            return View(model);
        }
        // One database call to check if the user exists
        User user = database.Users.Where(p => p.UserID == model.UserID).FirstOrDefault();
        if (user != null && !user.active)
        {
            user.active = true;
            // Save and redirect
        }
        else if (user != null)
        {
            ModelState.AddModelError(string.Empty, "USER already exists!");
            model.DepartmentList = ... // assign the SelectList
            return View(model);
        }
        user = new User
        {
            UserID = model.UserID,
            lastname = model.lastname,
            .... // set other properties of User
            Last_Modified = System.DateTime.Now
        }
        // Save and redirect
    }
