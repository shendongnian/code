    public ActionResult Edit(RequestViewModel model)
    {
        if (ModelState.IsValid)
        {
            var currentUser = User.Identity.Name;
            var emp = db.Employees.SingleOrDefault(e => e.ApplicationUser == db.Users.FirstOrDefault(u => u.UserName.Equals(currentUser)));
            if (emp != null)
            {
                var model = GetRequestById(model.Id) //Or whatever method you have for this
                //Update whatever you want, basically all apart from CreatedBy
                //Save the updated model
            }
         // some code
      }
    }
