    public void Configuration(IAppBuilder app)
    {
        _httpConfiguration = new HttpConfiguration();
        _httpConfiguration.MapHttpAttributeRoutes();
        ...
        app.Use<RouteTemplateMiddleware>(_httpConfiguration.Routes);
        ...
    }
