    [HttpPost]
    public ActionResult SelectDay(string Days)
    {           
        return RedirectToAction("ViewByDay", new {Days = Days});
    }
