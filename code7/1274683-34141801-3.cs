    var result = crit.SetProjection(
        Projections.ProjectionList()
            .Add(Projections.Min(propertyName), "MinProperty") // "min" + propertyName)
            .Add(Projections.Max(propertyName), "MaxProperty") // "max" + propertyName)
        )
        .SetResultTransformer(Transformers.AliasToBean<MyDto>())
        .UniqueResult<MyDto>();
