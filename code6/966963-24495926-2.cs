    [AllowAnonymous]
    [AcceptVerbs(HttpVerbs.Get)]
    public JsonResult StateList(string Id)
    {
        // Get the country by Country Code
        var country = dbLocations.Countries.FirstOrDefault(c => c.CountryCode == Id);
        // Get all states where countryId equals the Id from the action
        var states = from State s in dbLocations.States
                   where s.CountryId == country.Id
                   select s;
        return Json(new SelectList(states.ToArray(), "StateCode", "StateName"), JsonRequestBehavior.AllowGet);
    }
