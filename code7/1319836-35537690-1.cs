	public virtual async Task<IActionResult> Index()
	{
		TViewModel viewModel = Activator.CreateInstance<TViewModel>();
		viewModel.MyProperty="test";
		return View(viewModel);
	}
