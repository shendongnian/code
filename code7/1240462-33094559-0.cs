    //
    // GET: /Account/RegisterLoyalty
    [AllowAnonymous]
    public ActionResult RegisterLoyalty()
    {
        return View();
    }
    
    //
    // POST: /Account/RegisterLoyalty
    [HttpPost]
    [AllowAnonymous]
    public ActionResult RegisterLoyalty(RegisterLoyaltyViewModel model)
    {
        var db = new AccountLoyaltyDbContext();
    
        var emailExists = db.Loyalties.Any(x => x.EmailAddress == model.EmailAddress);
    
        if (emailExists)
        {
            return RedirectToAction("X");
        }
    
        db.Loyalties.Add(model);
        db.SaveChanges();
    
        return RedirectToAction("Y");
    }
    
    //
    // GET: /Account/X
    [AllowAnonymous]
    public ActionResult X()
    {
        return View();
    }
    
    //
    // GET: /Account/Y
    [AllowAnonymous]
    public ActionResult Y()
    {
        return View();
    }
