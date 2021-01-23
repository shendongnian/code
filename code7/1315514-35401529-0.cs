    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(City city)
    {
        if (ModelState.IsValid)
        {
            ....
        }
        ViewBag.StateList = new SelectList(db.States, "State_Id", "State_Name"); // add this
        return View(city);
    }
