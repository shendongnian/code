    bool? _sqlGeneratesID;
    bool IRepository<TEntity>.IsStoreGeneratedIdentity()
    {
        if (!_sqlGeneratesID.HasValue)
        {
            var items = (_context as IObjectContextAdapter)?.ObjectContext.MetadataWorkspace.GetItems(DataSpace.SSpace).OfType<EntityType>();
            var entity = items.Single(x => x.Name == typeof(TEntity).Name);
            _sqlGeneratesID = entity.KeyProperties.FirstOrDefault()?.IsStoreGeneratedIdentity ?? false;
        }
        return _sqlGeneratesID.Value;
    }
