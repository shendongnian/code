    string controller = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
    string action = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
    string area = String.Empty;            
    object areaObject;
    if (htmlHelper.ViewContext.RouteData.DataTokens.TryGetValue("area", out areaObject))
    {
        area = areaObject as string; 
    }
    string key = String.Format("{0}:{1}:{2}", action, controller, area);
