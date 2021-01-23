    .Mappings(arg =>
    {
        var autoPersistenceModel = AutoMap.Source(typeSource);
        foreach (var overrideType in typeSource.GetOverrideTypes())
        {
            autoPersistenceModel.Override(overrideType);
        }
        foreach (var conventionType in typeSource.GetConventionTypes())
        {
            autoPersistenceModel.Conventions.Add(conventionType);
        }
        arg.AutoMappings.Add(autoPersistenceModel);
    })
