    public ActionResult Edit(string id)
    {
       var user = UserManager.FindById(id);
       var model = new UserIdentityModel();
       ///Fill all fields of the model      
       return View(model);
    }
    
    // POST: UserAdmin/Edit/5
    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(UserIdentityModel model)
    {
       ...
       foreach(var role in model.Roles)
       {
          ...
       }
