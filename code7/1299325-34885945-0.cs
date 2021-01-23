    config.Routes.MapHttpRoute(
        name: "myroute",
        routeTemplate: "api/my/route/{userID}",
        defaults: new { controller = "my", userID = RouteParameter.Optional }
    );
    public string Post([FromBody]string value, Guid userID)
    {
        return "Message Received for User: " + userID.ToString();
    }
    public string Post([FromBody]string value)
    {
        Guid userID = Guid.NewGuid();
        return "Message Received for User: " + userID.ToString();
    }
