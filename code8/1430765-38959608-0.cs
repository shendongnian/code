    public async ActionResult StartJob(int[] instList)
    {
        await CheckPermissions;
        var jr = new JsonNetResult();
        jr.Formatting = Newtonsoft.Json.Formatting.Indented;
        jr.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        jr.Data = (inQueue <= 0?0:inQueue);
        return jr;
    }
    public async Task CheckPermissions()
    {
        for (int i = 0; i <= 100; i++)
        {                
            //Thread.Sleep(100); // Don't use this
            //update the html element id status message
        }
    }
