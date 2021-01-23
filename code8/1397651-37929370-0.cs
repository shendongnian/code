    app.UseMvc(routes =>
    {
        routes.MapRoute(
            "HomeRoute", 
            "{action}/{id}", 
            new 
            { 
                controller = "Home", 
                action = "Index", 
                id = UrlParameter.Optional
            });
    });
