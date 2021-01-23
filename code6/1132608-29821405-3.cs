    public async Task<JsonResult>  GetLotsOfStuff()
    {
        var tasks = collection.Select(q => GetDetailAboutTheThing(q.Id));
        var things = await Task.WhenAll(tasks);
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
