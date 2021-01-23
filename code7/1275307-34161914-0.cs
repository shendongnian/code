    public JsonResult AutoCompleteSearch(string SearchString)
    {
        var values = from s in db.Customers
                                  select s.CustomerNumber;
    
        var namelist = values.Where(n => n.ToLower().StartsWith(SearchString.ToLower()));
        return Json(namelist, JsonRequestBehavior.AllowGet);
    }
