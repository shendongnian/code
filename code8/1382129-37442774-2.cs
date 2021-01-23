    private static IEnumerable<VersionedRoute> GetRoutes(int version)
    {
        var routes = new List<VersionedRoute>();
        if (version >= 1)
        {
            var versionedRoutes = new List<VersionedRoute>
            {
                new VersionedRoute(
                    version,
                    "Test",
                    "v1/Members/{id}/{action}",
                    new RouteValueDictionary
                    {
                        {"controller", "Members"},
                        {"action", "Test"}
                    })
            };
            routes.AddRange(versionedRoutes);
        }
        if (version >= 2)
        {
            var versionedRoutes = new List<VersionedRoute>{
                new VersionedRoute(
                    version,
                    "TestV2",
                    "v2/Members/{id}/{action}",
                    new RouteValueDictionary
                    {
                        {"controller", "MembersV2"},
                        {"action", "Test"}
                    }),
            };
            routes.AddRange(versionedRoutes);
        }
        return routes;
    }
