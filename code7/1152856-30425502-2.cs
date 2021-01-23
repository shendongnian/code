	[HttpGet]
    public ActionResult Index()
    {
		var lists = new Lists();
		var names = lists.ListFiles();
		ViewBag.List = names;
        return View();
    }
