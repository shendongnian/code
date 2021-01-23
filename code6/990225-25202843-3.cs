    public JsonResult StateList(int? id)
    {
        var state = _countryState.GetAllState(id);
        return Json(new SelectList(state, "CountryId", "StateName"), JsonRequestBehavior.AllowGet);
    }
