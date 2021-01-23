    public JsonResult AutoCompleteCategory(string term)
    {
        var result = (from r in db.Activities
                      where r.subcategory.ToUpper().Contains(term.ToUpper())
                      select new { r.subcategory }).Distinct();
        return Json(result, JsonRequestBehavior.AllowGet);
    }
