    context.MapRoute(
                "DetailsCustom",
                "Company/Employees/{name}",
                new { controller = "Employees", action = "Details"},
                namespaces: new[] { "MySite.Areas.Company.Controllers" }
            );
