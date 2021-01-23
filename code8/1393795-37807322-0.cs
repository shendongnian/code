	[HttpGet]
	[Route("~/", Order = 2)]
	[Route("", Order = 1)]
	public ActionResult List()
	{
		return View();
	}
