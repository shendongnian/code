    public ActionResult Autocomplete(string term)
    {
        var model = db.Customers
                       .Where(m => term == null || m.Customer_Name.StartsWith(term))
                       .Take(10)
                       .Select(m => new
                       {
                           label = m.Customer_Name,
                           id = m.Ship_To_Code
                       }).ToArray();
    
        return Json(model, JsonRequestBehavior.AllowGet);
    }
