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
		var model = FooModel as TempData["TempModel"];
		 
		return View(model);
	}
