    public JsonResult FillMyCity(int country)
    {
        // No need for .ToList()
        var cities = db.Cities.Where(x => x.countryid == country).Select(item => new
        {
            cityid = item.cityid,
            name = item.name
        }).Enumerable();
        return Json(cities); // its a POST so no need for JsonRequestBehavior.AllowGet
    }
    
