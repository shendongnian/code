    [HttpGet]
    		public ActionResult Index()
    		{
    			ModelState.AddModelError("Error1", "Querystring error");
    			return View(new SampleViewModel());
    		}
