    [HttpGet]
    public ActionResult AjaxMakeHorseEntry()
    {
        var model = new Race();
        model.HorsesInRace.Add(new Horse());
        return PartialView(model);
    }
