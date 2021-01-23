    [HttpGet]
    public ActionResult ValueAction(ValueEnum result)
    {
        //irrelevant code
        ViewBag.Values = Enum.GetValues(typeof(ValueEnum))
    					.OfType<ValueEnum>()
    					.Select(x => new SelectListItem 
    						{ 
    							Text = x.GetCustomAttribute<DescriptionAttribute>().Description,
    							Value = ((byte)x).ToString()
    						});
        return View();
    }
