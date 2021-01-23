    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           
      routes.MapRoute("ProcessStore","{controller}/{storeName}"
                                        ,new { controller = "Home", action = "ProcessStore"});
           
      routes.MapRoute("Default", "{controller}/{action}/{id}",
                   new { controller = "Home", action = "Index", id = UrlParameter.Optional });  
    }
