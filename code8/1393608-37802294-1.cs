    public ActionResult Create([Bind(Include = "Make,Model")] Car car)
    {
        if(!checkSpelling(car.Make)) {
            ModelState.AddModelError("Make", "Check your spelling");
        }
        if (ModelState.IsValid) {
            //Save changes
        }
        return View(car);
    }
