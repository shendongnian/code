	// changed signature to async and Task<ActionResult>
	[HttpPost]
	public async Task<ActionResult> Index(HttpPostedFileBase file)
	{
		if (file != null && file.ContentLength > 0)
		{
			var fileName = System.IO.Path.GetFileName(file.FileName);
			var path = System.IO.Path.Combine(("C:\\Dev\\ProductionOrderWebApp\\Uploads"), fileName);
			file.SaveAs(path);
			// add await
			await CSVReader(fileName);
		}
		return RedirectToAction("Index");
	}
    // did not check the code in the method but the signature should return type Task
	public static async Task CSVReader(string fileName)	{/*existing/unchanged code*/}
