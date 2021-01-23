    public IActionResult Index()
    {
        var model = _service.GetAll().Select(c => new ContractViewModel {
            Id = _protector.Protect(c.Id.ToString()),
            Name = c.Name }).ToList();
        return View(model);
    }
