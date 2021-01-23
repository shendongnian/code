    var resourceManagers = new Dictionary<string, IDictionary<string, IResourceManagerAdapter>>();
    foreach (var tenant in _tenants)
    {
        var resourceDictionnary = typeof(ResourceFactory)
            .Assembly
            .GetTypes()
            .Where(t => t.IsClass && t.Namespace == "Resources." + tenant)
            .ToDictionary<Type, string, ResourceManager>
                 (resourceFile => resourceFile.Name,
                  resourceFile => new ResourceManager("Resources." + tenant + "." + resourceFile.Name, typeof(ResourceFactory).Assembly));
        resourceManagers.Add(tenant, resourceDictionnary);
    }
