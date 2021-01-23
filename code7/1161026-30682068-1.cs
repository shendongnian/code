	[HttpGet]
	public ActionResult Index()
	{
		return View(new SampleViewModel());
	}
	[HttpPost]
	public JsonResult PostData(SampleViewModel model)
	{				
		return Json(model);
	}
