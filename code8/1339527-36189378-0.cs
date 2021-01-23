    public bool IsStoreGeneratedIdentity<TEntity>()
    {
        var entityContainerMappings = (this as IObjectContextAdapter).ObjectContext
            .MetadataWorkspace.GetItems(DataSpace.CSSpace)
            .OfType<EntityContainerMapping>();
        var entityTypeMappings = entityContainerMappings
            .SelectMany(m => m.EntitySetMappings
                .Where(esm => esm.EntitySet.ElementType.Name == typeof(TEntity).Name))
            .SelectMany(esm => esm.EntityTypeMappings).ToArray();
        var keyMappings = (from km in entityTypeMappings.SelectMany(etm => etm.EntityType.KeyMembers)
            join pm in entityTypeMappings.SelectMany(etm => etm.Fragments)
                .SelectMany(mf => mf.PropertyMappings)
                .OfType<ScalarPropertyMapping>()
                on km.Name equals pm.Property.Name
            select pm
            );
        return keyMappings.Any(pm => pm.Column.IsStoreGeneratedIdentity);
    }
