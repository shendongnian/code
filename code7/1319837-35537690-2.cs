	public virtual async Task<IActionResult> Index()
	{
		TViewModel viewModel = new TViewModel();
		viewModel.MyProperty="test";
		return View(viewModel);
	}
