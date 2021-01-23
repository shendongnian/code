    public class CheckValuesAttribute : ActionFilterAttribute
    {
      public string Value1 { get; set; }
      public string Value2 { get; set; }
    
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        var isValue2Valid = filterContext.ActionParameters.ContainsKey(Value2) &&
                            filterContext.ActionParameters[Value2] == const_SomeValue;
        var isValue1Valid = filterContext.ActionParameters.ContainsKey(Value1) &&
                            filterContext.ActionParameters[Value2] == GetCurrentId();
    
        if (!isValue1Valid || !isValue2Valid)
          filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index"}));
      }
    }
