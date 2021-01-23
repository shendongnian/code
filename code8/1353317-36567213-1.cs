    public ActionResult Create()
    {
        OrganizationUserSignedByVM model= new OrganizationUserSignedByVM();
        ConfigureViewModel(model);
        return View(model);
    }
    public ActionResult Create(OrganizationUserSignedByVM model)
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model);
            return View(model);
        }
        // initialise a new instance of your data model(s) and save
        // redirect
    }
    private void ConfigureViewModel(OrganizationUserSignedByVM model)
    {
        model.BankList = new SelectList(db.Banks, "ID", "Title");
        ....
    }
