    public async JsonResult ProcessSynchronization(int sourceId, string[] cities)
    {
        var ret = false;
        try
        {              
            if (sourceId == 1)
            { 
                var cityDeep = (string[])cities.Clone();
                Logger.Info("ABout to start BeginSynchronization ..");
                await Task.Factory.StartNew(() =>
                {
                    Logger.Info("ABout to start BeginSynchronization enter..");
                    BeginSynchronization(cityDeep);
                });
                ret = true;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(LogUtility.BuildExceptionMessage(ex), ex);
            return Json(new { result = ret, responseText = "Customer could not be activated." });
        }
        return Json(new { result = ret, responseText = "Synchronization started." });
    }
