    public static class Helpers
        {
            public static void SetupControllerForTests(ApiController controller)
            {
                var config = new HttpConfiguration();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/products");
                var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
                var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "products" } });
    
                controller.ControllerContext = new HttpControllerContext(config, routeData, request);
                controller.Request = request;
                controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            }
        }
