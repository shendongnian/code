	[HttpPost]
    [ValidateAntiForgeryToken]
	public ActionResult Index(int userId)
    {
		// MVC's DefaultModelBinder is smart enough to map your form
		// post values to objects of the correct type, given the name in the form
		
		// Get the data from your repository etc.
		var model = GetUser(userId);
		
		// Then return this model to the view:
		return View(model);
	}
