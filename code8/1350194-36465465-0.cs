    [ChildActionOnly]
    public ActionResult RegisterDetails(UserModel model)
    {
        if (model == null || model.Id == Guid.Empty)
        {
            model = new UserModel(GetUser());
            ModelState.Clear();
        }
    
        return View(model);
    }
