    public ViewResult Create()
    {
        PersonViewModel model = new PersonViewModel
        {
            Person = new Person (),
            Cities = repository.Cities.ToList()
        };
        return View(model);
    }
