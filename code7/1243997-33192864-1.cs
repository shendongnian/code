    [HttpGet]
	public ActionResult Edit()
	{
		SampleViewModel model = new SampleViewModel()
		{
			SelectedYear = 2001, // set default
			SelectedMonths = new List<int>{ 1, 2 }, // set default based on default year
            Years = new List<SelectListItem>
			{
				new SelectListItem(){ Value = "2000", Text = "2000" },
				new SelectListItem(){ Value = "2001", Text = "2001" }
			},
            Months = new List<SelectListItem>
			{
				new SelectListItem(){ Value = "1", Text = "January" },
				new SelectListItem(){ Value = "2", Text = "February" },
                ....
			}
        };
        return View(model);
	}
