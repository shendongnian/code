    config.Routes.MapHttpRoute(
        name: "fileFunctionsDelete",
        routeTemplate: "api/{controller}/{appName}/{userID}/Delete",
        defaults: new {
            appName = RouteParameter.Optional,
            userID= RouteParameter.Optional,
            action = "Delete"
        },
        constraints: new { HttpMethod = new HttpMethodConstraint(HttpMethod.Post) });
    );
    
    [HttpPost]
    [ActionName("Delete")]
    public async Task<HttpResponseMessage> DeleteUser(
        string controller,
        string appName,
        string userID)
    {
    }
