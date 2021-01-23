    [AllowAnonymous]
    [AcceptVerbs(HttpVerbs.Get)]
    public JsonResult StateList(string Id)
    {
        // Get all states where countryId equals the Id from the action
        var states = from State s in dbLocations.States
                   where s.CountryId == Id
                   select s;
        return Json(new SelectList(states.ToArray(), "StateCode", "StateName"), JsonRequestBehavior.AllowGet);
    }
