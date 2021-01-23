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
                    "/Members/V1/{action}",
                    new RouteValueDictionary
                    {
                        {"controller", "Members"},
                        {"action", "Test"},
                        {"id", "v1"}
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
                    "/Members/V2/{action}",
                    new RouteValueDictionary
                    {
                        {"controller", "MembersV2"},
                        {"action", "Test"},
                        {"id", "v2"}
                    }),
            };
            routes.AddRange(versionedRoutes);
        }
        return routes;
    }
