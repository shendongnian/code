    public ActionResult Edit(RequestViewModel model)
    {
        if (ModelState.IsValid)
        {
            var currentUser = User.Identity.Name;
            var emp = db.Employees.SingleOrDefault(e => e.ApplicationUser == db.Users.FirstOrDefault(u => u.UserName.Equals(currentUser)));
            if (emp != null)
            {
                var domainModel = GetRequestById(model.Id) //Or whatever method you have for this
                //Update whatever you want in domainModel, basically all apart from CreatedBy from the model
                domainModel.Property1 = model.Property1 
                //Save the updated domainModel
            }
         // some code
      }
    }
