    var container = new Container(x =>
    {
        x.Policies.SetAllProperties(
            policy => policy.WithAnyTypeFromNamespace("StructureMap.Testing.Widget3"));
    });
