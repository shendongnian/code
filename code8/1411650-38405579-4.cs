    private static void SetupControllerForTests(ApiController controller) {
        var config = new HttpConfiguration();
        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/candidatemanager");
        var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
        var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "products" } });
        controller.ControllerContext = new HttpControllerContext(config, routeData, request);
        controller.Request = request;
        controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        //commented this out as it was causing Request to be null
        //controller.ActionContext=new HttpActionContext();
    }
