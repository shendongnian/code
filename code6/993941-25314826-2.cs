    routes.MapRoute(
         "Route for v1", // Route name
         "areav1/{controller}/{action}/{id}", // URL with parameters
         new { controller = "Values", action = "GetValues", id = UrlParameter.Optional },           new string[] { "MvcApplication.Controllers.v1"}
    );
    routes.MapRoute(
         "Route for v2", // Route name
         "areav2/{controller}/{action}/{id}", // URL with parameters
         new { controller = "Values", action = "GetValues", id = UrlParameter.Optional },           new string[] { "MvcApplication.Controllers.v2"}
    );
