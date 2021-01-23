        var routes = httpConfiguration.Routes
                .OfType<IEnumerable>()
                .Single();
        var manifest = routes?
                .Cast<HttpRoute>()
                .Select(route => route.RouteTemplate)
                .ToList();
