    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(EditLoginVM model)
    {
        if (ModelState.IsValid)
        {
            var updateModel = new Model();
            updateModel.Login = model.Login;
            if (/* user is admin, don't use EditLoginVM.IsAdmin!!!! */)
            {
                model.Password = model.Password;
            }
            UpdateModel(model);
            return RedirectToAction("Index");
        }
        model.IsAdmin = /* reset it just in case of overposting */;        
        return View(model);
    }
