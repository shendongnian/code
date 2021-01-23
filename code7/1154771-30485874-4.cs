    public ActionResult Autocomplete(string term)
    {
        try
        {
            var model = _db.product_data // your data here
                .Where(p => p.product.StartsWith(term))
                .Take(10)
                .Select(p => new
                {
                    // jQuery UI needs the label property to function 
                    label = p.product.Trim()
                });
    
            // Json returns [{"label":value}]
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            Settings.ReportException(ex);
            return Json("{'ex':'Exception'}");
        }
    }
