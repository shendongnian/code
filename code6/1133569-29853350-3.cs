    [HttpPost]
    public ActionResult getCicitesAction(int provinceId)
    {
         var cities = db.cities.Where(a => a.provinceId == provinceId).Select(a => "<option value='" + a.cityId + "'>" + a.cityName + "'</option>'";
         return Content(String.Join("", cities));
    }
