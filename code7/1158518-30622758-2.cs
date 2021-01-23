    IVersionableDbObject<TEntity> versionableSource = entity as IVersionableDbObject<TEntity>;
    if (versionableSource != null)
    {
        bool versionExists = innerContext.Set<TEntity>().Where(versionableSource.LookupSelector).Any();
        if (!versionExists)
            return new ValidationResult(string.Format(FooResources.EntityUpdateVersionConflictError,
                        BitConverter.ToInt32(versionableSource.Version, 0)));
    }
