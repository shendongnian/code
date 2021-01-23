    public async Task<JsonResult> Get_Fare_TypeAsync()
    {
      var types = (await db.Types.Select(e => new { ID = e.Code, Description = e.Description, Value = e.Code, SortOrder = e.SortOrder }).ToListAsync()).OrderBy(x => x.SortOrder);
      return Json(types, JsonRequestBehavior.AllowGet);
    }
