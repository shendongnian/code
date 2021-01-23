    [HttpGet] // Its a get,  not a post (change the ajax option)
    public ActionResult _GetSubDepartment(int? DepartmentCategoryID) // The parameter should be int (not nullable) or test for null
    {
      var data = db.vwDimDepartments.Where(m => m.DepartmentCategoryID == DepartmentCategoryID).Select(d => new
      {
        Value = d.DepartmentID,
        Text = d.DepartmentName
      };
      return Json(data, JsonRequestBehavior.AllowGet);
    }
