	public ActionResult Page()
	{
		var tempModel = new FooModel
		{
			Foo = "Bar"
		};
		
		TempData["TempModel"] = tempModel;
		
		return RedirectToAction("SeachResults" new { searchParameters = "baz" });
	}
	public ActionResult SeachResults(string searchParameters)
	{
		var model = TempData["TempModel"] as FooModel;
		 
		return View(model);
	}
