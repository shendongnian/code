     multiselectFilter: options.join(',')
    [HttpGet]
		public ActionResult FilterReport(string filterOne, string filterTwo, int? page, string multiselectFilter)
		{
			string[] array = multiselectFilter.Split(',');
			//returns partial view
		}
