    public ActionResult GetRegionsByCountryId(string countryId)
        {
           var country = _countryService.GetCountryById(Convert.ToInt32(countryId));
            var states = _stateProvinceService.GetStateProvinces(country != null ? country.Id : 0).ToList();
            var result = (from s in states
                select new {id = s.Id, name = s.Title})
                .ToList();
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
