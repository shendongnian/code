    public IList<string> GetWidgetZones()
    {
        return new[] { "order_summary_content_after" };
    }
    public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
    {
        actionName = "Index";
        controllerName = "CheckCart";
        routeValues = new RouteValueDictionary {
            { "Namespaces", "Nop.Plugin.Misc.CheckCart.Controllers" },
            { "area", null },
            { "widgetZone", widgetZone }
        };
    }
