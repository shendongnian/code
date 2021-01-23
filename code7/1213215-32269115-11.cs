    public ActionResult Edit(int id)
    {
        PostViewModel model=_postManager.Get(id);
        model.Privileges=new PrivilegesViewModel
        {
            CanEdit=HttpContext.Current.User.Identity.CanEdit(),
            // and so on
        }
        return View(model);
    }
