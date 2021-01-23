    private IEnumerable<SqlBulkCopyColumnMapping> GetColumnMappings<T>()
    {
        var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
        var entityPropMembers = storageMetadata
            .Where(s => (s.BuiltInTypeKind == BuiltInTypeKind.EntityType))
            .Select(s => (EntityType)s)
            .Where(p => p.Name == typeof(T).Name)
            .Select(p => (IEnumerable<EdmMember>)(p.MetadataProperties["Members"].Value))
            .First();
        var sourceColumns = entityPropMembers.Select(m => (string)m.MetadataProperties["PreferredName"].Value);
        var destinationColumns = entityPropMembers.Select(m => m.Name);
        return Enumerable.Zip(sourceColumns, destinationColumns, (s, d) => new SqlBulkCopyColumnMapping(s, d));
    }
