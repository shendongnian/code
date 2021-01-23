    public IActionResult Index()
    {
        var model = new CountryViewModel();
        model.Country = "CA";
        return View(model);
    }
