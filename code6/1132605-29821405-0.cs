    public async Task<JsonResult>  GetLotsOfStuff()
    {
        IEnumerable<Task<ThingDetail>> tasks = collection.Select(q => GetDetailAboutTheThing(q.Id)));
    
        var jointTask = Task.WhenAll(tasks);
    
        IEnumerable<ThingDetail> things = await jointTask;
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
