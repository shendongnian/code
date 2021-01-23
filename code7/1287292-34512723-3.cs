    [HttpPost]
    public ActionResult Edit(UserProfileViewModel model)
    {
      if(ModelState.IsValid)
      {
        //to do : create an object of your entity and save. use model.UserName,model.Age etc
       // to redirect to some success page
      }
      return View(model);
    }
