    public ActionResult Register(Registration model)
    {
        bool isValid = IsEmailUnique(model.Email);
        if (!isValid)
        {
            ModelState.AddModelError("Email", "...");
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // save and redirect
    }
    
