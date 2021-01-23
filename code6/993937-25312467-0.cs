    MSBuildWorkspace.Create(
        ImmutableDictionary<string, string>.Empty,
        MefHostServices.Create(
            MefHostServices.DefaultAssemblies.Add(Assembly.Load(...))
        )
    );
