    [HttpGet]
    public JsonResult GetDates()
    {
        var result = new List<DateTime> {new DateTime(2013, 1, 1), new DateTime(2013, 4, 4)}
            .Select(x => new {id = x, name = x.ToString(CultureInfo.InvariantCulture)});
            return Json(result, JsonRequestBehavior.AllowGet);
    }
