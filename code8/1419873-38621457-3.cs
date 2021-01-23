    public IActionResult Index()
    {
        var model = new CountryViewModel();
        model.Country = "CA";
        model.Countries = db.Countries
                            .Select(x => new SelectListItem { Value = x.Id, Text = x.Name })
                            .ToList();
        return View(model);
    }
