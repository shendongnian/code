    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
      var sharedLogic = filterContext.Controller.TempData["ShareLogicValue"]
        as String;
      var logName = "OnActionExecuted";
      if (sharedLogic != null)
      {
        logName += ":" + sharedLogic;
      }
      Log(logName, filterContext.RouteData);       
    }
