    [HttpPost]
    public ActionResult Create(AccountViewModel model)
    {
        if (ModelState.IsValid)
        {
          brugere OpretUser = new brugere();
          OpretUser.kon = model.SelectedKon;
          //Do other useful things and redirect to a Success page.
        }
        //TO DO : Reload the model.Kon collection again here.
        return View(model)
    }
