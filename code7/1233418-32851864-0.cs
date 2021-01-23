    routes.Add("Search",
        new LowercaseDashedRoute(
        "search/{searchType}/{state}/{county}/{city}",
        new RouteValueDictionary(new {
            controller = "Home",
            action = "Search",            
            county = UrlParameter.Optional,
            city = UrlParameter.Optional }),
        new RouteValueDictionary(new { searchType = searchTypeConstraint, county="\\S+-county" }),
        new LowercaseDashedRouteHandler()));
