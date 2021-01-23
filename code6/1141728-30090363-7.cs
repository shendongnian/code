    public JsonResult FetchCities(int provinceId) // its a GET, not a POST
    {
        var cities = db.Cities.Select(c => new
        {
          ID = c.ID,
          Text = c.Text
        }
        return Json(cities, JsonRequestBehavior.AllowGet);
    }
