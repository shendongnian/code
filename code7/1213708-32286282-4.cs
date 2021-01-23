    public JsonResult SelectLine()
    {
      var data = db.Persons.GroupBy(p => p.Gender).Select(p => new
      {
        group = p.Key,
        options = p.Select(o => new
        {
          text = o.Name,
          value = o.ID
        })
      });
    return Json(data, JsonRequestBehavior.AllowGet);
    }
