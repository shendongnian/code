    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      // some condition code to target a specific method in the controller
      // Example
      if (filterContext.ActionDescriptor.ActionName == "getuser") // <-- your method
      {
        // put your token based authentication code here
      }
    
      base.OnActionExecuting(filterContext);
    }
