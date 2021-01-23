    RouteData routeData = new routeData();
    routeData.Values.Add("controller", "Error");
    routeData.Values.Add("action","Error404");
    routeData.Values.Add("Summary","Error");
    routeData.Values.Add("Description", ex.Message);
    IController controller = New ErrorController()
    controller.Execute(New RequestContext(New HttpContextWrapper(Context), routeData));
