    [HttpPost]
    public ActionResult PostStuff(FormCollection formCollection)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
    
        //If data is POSTed as a form
        foreach (var key in formCollection.AllKeys)
        {
            var value = formCollection[key];
            data.Add(key, value);
        }
                
        return Json(data, "application/json", JsonRequestBehavior.AllowGet);
    }
