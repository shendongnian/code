        [HttpGet]
		public ActionResult Index()
		{
			return View(new SampleModel());
		}
		[HttpPost]
		public ActionResult Index(SampleModel model)
		{		
			if(model.WeightFrom.HasValue && model.WeightTo.HasValue)
			{
				if(model.WeightFrom.Value < model.WeightTo.Value)
				{
					ModelState.AddModelError("", "Weight from most be smaller than Weight to. Please fix this error.");	
				}
			}
			
			if(!ModelState.IsValid)
			{
				return View(model);	
			}
			
			return View(new SampleModel());
		}
