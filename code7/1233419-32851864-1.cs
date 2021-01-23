    routes.Add("Search",
        new LowercaseDashedRoute(
        "search/{searchType}/{state}/{city}",
        new RouteValueDictionary(new {
            controller = "Home",
            action = "Search",
            city = UrlParameter.Optional }),
        new RouteValueDictionary(new { searchType = searchTypeConstraint }),
        new LowercaseDashedRouteHandler()));
