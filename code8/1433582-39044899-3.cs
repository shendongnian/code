    public ActionResult StateList(int CountryID)
    {
        var states = db.States.Where(x => x.CountrId==CountryID).ToList(); 
        //this ToList() call copies the data to a new list variable.
        var stateOptions = states.Select(f => new SelectListItem { 
                                                             Value = f.StateID.ToString(), 
                                                             Text = f.StateName }
                                        ).ToList();
        if (HttpContext.Request.IsAjaxRequest())
            return Json(stateOptions, JsonRequestBehavior.AllowGet);
        return View(states);
    }
