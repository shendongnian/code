    public List<Type> GetAllTypes()
    {
        var trs = GetTypeDiscoveryService();
        var types = trs.GetTypes(typeof(object), true /*excludeGlobalTypes*/);
        var result = new List<Type>();
        foreach (Type type in types)
        {
            if (type.IsPublic)
            {
                if (!result.Contains(type))
                    result.Add(type);
            }
        }
        return result;
    }
    private ITypeDiscoveryService GetTypeDiscoveryService()
    {
        var dte = GetService<EnvDTE.DTE>();
        var typeService = GetService<DynamicTypeService>();
        var solution = GetService<IVsSolution>();
        IVsHierarchy hier;
        var projects = dte.ActiveSolutionProjects as Array;
        var currentProject = projects.GetValue(0) as Project;
        solution.GetProjectOfUniqueName(currentProject.UniqueName, out hier);
        return typeService.GetTypeDiscoveryService(hier);
    }
    private T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
