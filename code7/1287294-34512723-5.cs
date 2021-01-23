    public ActionResult Edit(string id)
    {
     
       var model = _kletsContext.Users.FirstOrDefault(m => m.Id == id);
       var profile = _kletsContext.Profiles.FirstOrDefault(m => m.UserId == model.Id);
       if(model == null)
       {
           return RedirectToAction("Index");
       }
       var vm = new UserProfileViewModel
       {
           UserId = model.Id,
           UserName = model.UserName,
           Email = model.Email,
           Age = profile.Age
       };
       return View(vm);
    }
