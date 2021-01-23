    public ActionResult EditInformation()
    {
        //Select default value like this (of course if your db.States have an Id):
        ViewBag.State = new SelectList(db.States, "Id", "StateName", 1 /*Default Value Id or Text*/);
        . . .
        return View();
    }
