    public ActionResult Country() 
    {
        var model = new CountryViewModel();
        model.StaffList = new List<StaffViewModel>();
        // populate staff list from DB etc here
        return View(model);
    }
