	[HttpGet]
	public ActionResult Index()
	{
		this.Session["ItemName"] = _consultation.consultid
		
		return View(new SampleViewModel());
	}
