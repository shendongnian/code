    [AllowAnonymous]
    public ActionResult Register()
    {
        RegisterViewModel model = new RegisterViewModel();
        ConfigureViewModel(model);
        return View(model);
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model); // must reassign the SelectList
            return View(model);
        }
        .... // save and redirect
    }
    
    private ConfigureViewModel(RegisterViewModel model)
    {
        model.carrierList = new SelectList(db.Carriers, "Id", "name");
    }
