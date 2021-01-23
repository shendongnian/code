    public ActionResult MyView(int someId)
    {
        string json = this.GetJson(someId);
        var model = new MyViewModel(json);
        return this.View(model);           
    }
    
    private string GetJson(int id)
    {
        string cacheKey = "myJsonCacheKey" + id;
    
        string cachedJson = this.HttpContext.Cache[cacheKey] as string;
    
        if (cachedJson != null)
            return cachedJson;
    
        string actualJson = new WebClient().DownloadString("http://whatever");
        this.HttpContext.Cache.Insert(cacheKey, actualJson);
    
        return actualJson;
    }
