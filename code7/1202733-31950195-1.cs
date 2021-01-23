    [HttpGet]
    [ActionName("Index")]
    public ActionResult GetCar()
    {
    	ViewBag.OptionsAvailable = new List<string>
    	{
    		"Red",
    		"Yellow",
    		"Blue"
    	};
    	return View(new Car());
    }
    
    [HttpPost]
    [ActionName("Index")]
    public ActionResult PostCar(string[] checkboxes)
    {
    	Car car = new Car
    	{
    		ColorsSelected = new List<string>()
    	};
    
    	foreach (string value in checkboxes)
    	{
    		car.ColorsSelected.Add(value);
    	}
    	return RedirectToAction("Index");
    }
