    public ActionResult Index()
       {
             AddressModel model = new AddressModel();
            model.AvailableCountries.Add(new SelectListItem 
            { Text = "-Please select-", Value = "Selects items" });
             var countries = _repository.GetAllCountries();
             foreach (var country in countries)
            {
                model.AvailableCountries.Add(new SelectListItem()
                {
                    Text = country.Name,
                    Value = country.Id.ToString()
                });
            }
             return View(model);
        }
