    protected void Application_Error(object sender, EventArgs e) {
      Exception exception = Server.GetLastError();
      Response.Clear();
      HttpException httpException = exception as HttpException;
      if (httpException != null) {
    string action;
    switch (httpException.GetHttpCode()) {
      case 404:
        action = "HttpError404";
        break;
      case 500:
        action = "HttpError500";
        break;
      default:
        action = "HttpErrorGeneric";
        break;
      }
    RouteData routeData = new routeData();
    routeData.Values.Add("controller", "Error");
    routeData.Values.Add("action", action);
    routeData.Values.Add("Summary","Error");
    routeData.Values.Add("Description", ex.Message);
    IController controller = New ErrorController()
    controller.Execute(New RequestContext(New HttpContextWrapper(Context), routeData));
    }
