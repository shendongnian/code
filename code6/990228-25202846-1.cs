    public JsonResult StateList(int? countryId)
        {
          if (countryId != null && countryId.HasValue)
          {
              var state = _countryState.GetAllState(countryId.Value);
              return Json(new SelectList(state, "CountryId", "StateName"), JsonRequestBehavior.AllowGet);
          }
    
          return Json(null);    
            
        }
