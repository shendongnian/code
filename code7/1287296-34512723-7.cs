    [HttpPost]
    public ActionResult Edit(UserProfileViewModel model)
    {
      if(ModelState.IsValid)
      {
         var u = _kletsContext.Users.FirstOrDefault(m => m.Id == model.UserId);
         var p= _kletsContext.Profiles.FirstOrDefault(m => m.UserId == model.UserId);
        
         //Set the new values
         u.Email = model.Email;
         
         if(p!=null)
         {
            p.Age=model.Age;
            _kletsContext.Entry(p).State = EntityState.Modified;
         }
         else
         {
            // to do  :Create a new profile record
         }
         _kletsContext.Entry(u).State = EntityState.Modified;
        
        _kletsContext.SaveChanges();
         // to redirect to some success page
      }
      return View(model);
    }
