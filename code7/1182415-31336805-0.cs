    public ActionResult PageWiseData(int WidgetId, string FacilityIds, [DataSourceRequest]DataSourceRequest request)
    {
        IQueryable<AMI.WebRole.Models.Widgets.DeviceEventModel> totalresult = null;
    
        var totalresults = _deviceEventClient.DeviceEventsForExpandedView(WidgetId, 
              FacilityIds, TenantId, CustomerId, UserId,
               this.sessionContext.UserContextBag.CultureName);
    
            var results = totalresults.ToDataSourceResult(request);
            return Json(results);
      
    }
