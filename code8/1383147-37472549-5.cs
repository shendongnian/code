    [HttpGet]
    public ActionResult Index()
    {
        var person = sampleService.GetPersonById(1);
        var model = new IndexViewModel
        {
            Name = person.Name,
            PersonID = person.ID,
            SelectedCarId = person.Car.ID
        };
    
        model.AvailableCars = sampleService.GetAllCars()
                                            .Select(car => new SelectListItem
                                            {
                                                Text = $"{car.Make} - {car.Model}",
                                                Value = car.ID.ToString()
                                            })
                                            .OrderBy(sli => sli.Text)
                                            .ToList();
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(IndexViewModel model)
    {
        var person = sampleService.GetPersonById(model.PersonID);
        if(person != null)
        {
            person.Name = model.Name;
    
            //only update the person car if required.
            if(person.Car == null || person.Car.ID != model.SelectedCarId)
            {
                var car = sampleService.GetCarById(model.SelectedCarId);
                if (car != null)
                    person.Car = car;
            }
    
            sampleService.UpdatePerson(person);
        }
        return View();
    }
