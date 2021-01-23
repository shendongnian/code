    [HttpPost]
    public ActionResult Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Login");
        }
    
        return PartialView(model);
    }
