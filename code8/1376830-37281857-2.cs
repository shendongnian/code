    [HttpPost]
	public ActionResult Index(FormCollection collection)
	{
		// Get your suppressed elements (they will come in as a comma-delimited string)
        var suppressions = collection["suppressions"];
		return Content("Properties: [" + suppressions + "] were suppressed.");
	}
