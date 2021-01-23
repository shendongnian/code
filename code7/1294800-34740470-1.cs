    public IActionResult Index()
    {
        var countries = _customersContext.Countries.OrderBy(c => c.CountryName).Select(x => new { Id = x.Code, Value = x.Name });
    
        var model = new HomeViewModel();
        model.CountryList = new SelectList(countries, "Id", "Value");
    
        return View(model);
    }
