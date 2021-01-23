    routes.MapRoute(
                    "Default",                                              // Route name
                    "{controller}/{action}/{id}",                           // URL with parameters
                    new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.Index, id = "" }  // Parameter defaults
                );
