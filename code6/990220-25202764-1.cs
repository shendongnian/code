    public JsonResult StateList(int? countryId)  
    {
        if(countryId != null){
        var state = _countryState.GetAllState(countryId);
         return Json(new SelectList(state, "CountryId", "StateName"), JsonRequestBehavior.AllowGet);
        }
        else{
         return Json(new{});
        }
    }
