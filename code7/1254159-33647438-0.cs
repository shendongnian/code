    routes.MapRoute(
                    "Default", // Route name
                    "{controller}/{action}/{id}", // URL with parameters
                    new {area="Admin",  controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "X.Areas.Admin.Controllers" }
                    ).DataTokens.Add("area", "Admin");
