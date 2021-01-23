    public ViewResult List(string category)
    {
        var viewModel = Metrics = repository.Metrics
                .Select(p => new MatricListViewModel(p.cs_username)
                .ToList()
				
		return View(viewModel);
    }
