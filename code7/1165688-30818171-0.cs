    [HttpGet]
    public ActionResult Module()
    {
        repository.ListData = repository.GetData();
        return View(repository);
    }
