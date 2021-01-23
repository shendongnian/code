    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var data = MyIDParam;
        foreach(var kvp in _parameters)
        {
            data = data.Replace("{" + kvp.Key + "}", 
               kvp.Value.ToString());
        }
        //...
    }
