    public ActionResult TestDropDown()
    {
        var practices = new SelectList(db.Practices, "PracticeId", "PracticeName");
        ViewData["Practices"] = practices;
        return View();
    }
