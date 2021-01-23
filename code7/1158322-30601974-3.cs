	public ActionResult Index()
	{
		var li = new List<SelectListItem>();
		li.Add(new SelectListItem { Text = "Option One", Value = "option1" });
		li.Add(new SelectListItem { Text = "Option Two", Value = "option2" });
		var viewModel = new ViewModel 
		{ 
			ItemList = li, 
			MyOption = [here your code to fill this] 
		}
		
		return View(viewModel);
	}
