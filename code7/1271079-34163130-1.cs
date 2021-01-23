    var tablesToLoad = scripter.WalkDependencies(new DependencyWalker(server).DiscoverDependencies(filteredTables, DependencyType.Parents))
                               .Where(n => n.Urn.Type != "UnresolvedEntity")
                               .Select(n => server.GetSmoObject(n.Urn))
                               .OfType<Table>()
                               .ToArray();
