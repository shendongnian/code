        [AllowAnonymous]
            [HttpPost]
            public ActionResult Register(RegisterViewModel model) {
                if (!ModelState.IsValid) {
                    model.Initalize();
                    ModelState.AddModelError(string.Empty, "");
                    return View("Register", model);
        
                }
        
                if (ModelState.IsValid && model.Register != null) {
                    if (RegisterViewModel.RegisterNewUser(model.Register))
                        return RedirectToAction("RegisterSuccess");
                    else
                    {
                        ModelState.AddModelError("", NMPAccountResource.Failed);
                   //there needs to be code here to return the view.
                   return View("Register", model); //<--- this is missing
                   }
        
                }
                   //there needs to be code here to return the view.
                   return View("Register", model); //<--- this is missing
    
       }
