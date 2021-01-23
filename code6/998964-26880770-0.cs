    routes.MapRoute(
                    "Route",
                    "{controller}/{action}/{id}",
                    new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
                     new[]{"ProjectName.Areas.Admin.Controllers.AdminController"}
                );
