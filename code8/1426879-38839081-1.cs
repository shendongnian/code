    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
   
        routes.MapRoute("part","{studentProgram}/Participant/{action}",
            new { controller = "Participant", action = "Index" }
        );
       routes.MapRoute("course", "{studentProgram}/Course/{action}",
                           new { controller = "Course", action = "Index" }
       );
       routes.MapRoute("Default",
           "{controller}/{action}/{id}",
           new { controller = "Home", action = "Index", id = UrlParameter.Optional });        
    }
