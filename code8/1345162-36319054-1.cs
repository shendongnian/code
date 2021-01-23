    // GET: Drivers/Create
    public ActionResult Create()
    {
        var viewModel = new DriverViewModel();
        viewModel.Tenants = new SelectList(db.Tenants, "TenantID", "TenantName");
        return View(viewModel);
    }
