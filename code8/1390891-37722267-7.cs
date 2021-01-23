    [HttpPost]
    public ActionResult Create(FranchaiseVM viewModel)
    {
        if (!ModelState.IsValid)
        {
            model.StatusList = ... as per GET method
            model.Franchaises = ... as per GET method
           return View(viewModel);
        }
        // Initialize data model and set its properties
        Franchaise dataModel = new Franchaise()
        {
            Name = viewModel.Name,
            .... // map other properties
            Status = viewModel.Status, // not sure why you need to convert it
            StartDate = DateTime.Now;
        }
        _FranchaiseServices.Create(dataModel);
        return RedirectToAction("GetAll");
    }
