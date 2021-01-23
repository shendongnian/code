    [HttpPost]
    public ActionResult Create(CreateUserVm model)
    {
      if(ModelState.IsValid)
      { 
         // Posted file is available at model.UserImage property. You may save it to somewhere.
         // Quick Example of saving to disk
          var fName= Path.GetFileName(model.UserImage.FileName);
          fName = fName.Replace(" ", "_");
          fName = Guid.NewGuid().ToString()+fName;
        
          model.UserImage.SaveAs("~/"+fName);
          var u = new Users { Firstname = model.FirstName, Lastname=model.LastName };
          u.Password=model.Password;
          u.UserImage= fName;
          db.Users.Add(u);
          db.SaveChanges();
                
          return RedirectToAction("Index");       
      }
      return View(model);
    }
