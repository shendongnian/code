    protected override void OnException(ExceptionContext filterContext)
    { 
      Exception exception = filterContext.Exception;
      //Logging the Exception
      filterContext.ExceptionHandled = true;
 
 
      var Result = this.View("Error", new HandleErrorInfo(exception,
       filterContext.RouteData.Values["controller"].ToString(),
       filterContext.RouteData.Values["action"].ToString()));
 
      filterContext.Result = Result;
    
     }
