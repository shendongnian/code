    public JsonResult GetUserDates()
    {
        var id= "1231231234";
        var data = db.Test.Where(x => x.Id == id).Select(c => c.Date).Distinct()
                     .AsEnumerable()
                     .Select(x => new { 
                         Date = x.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                     });
                     
        return Json(data, JsonRequestBehavior.AllowGet);
    }
