    public EntityType ElementType(Type entityType)
    {
        var type = ObjectContext.GetObjectType(entityType);
        var objectContext = ((IObjectContextAdapter)this).ObjectContext;
        EntityType elementType;
        if (objectContext.MetadataWorkspace.TryGetItem(type.FullName, DataSpace.OSpace, out elementType))
        {
            return elementType;
        }
        return null;
    }
