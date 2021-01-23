    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(CreateUser model)
    {
       if (ModelState.IsValid)
       {
          try
          {
           // to do : Save something
          // read model.UserName & model.SelectedRoleId etc. 
            return RedirectToAction("Index", "Home");
          }
          catch (MembershipCreateUserException exception)
          {
              ModelState.AddModelError("", "Warning: Username exist...");
              //Reload the data now
              model.RolesList =GetRoles();
              return View(model);
          }
       }
       ModelState.AddModelError("", "Warning: Username exist....");
      //Reload the data now
       model.RolesList =GetRoles();
       return View(model);
    }  
