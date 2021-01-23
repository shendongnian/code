    public static class Utility {
        public static IEnumerable<string> GetTableNames<TEntity>(this DbContext context) {
            return GetTableNames(typeof(TEntity), context);
        }
        public static IEnumerable<string> GetTableNames(Type type, DbContext context) {
            var metadata = ((IObjectContextAdapter)context).ObjectContext.MetadataWorkspace;
            // Get the part of the model that contains info about the actual CLR types
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));
            // Get the entity type from the model that maps to the CLR type
            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == type);
            // Get the entity set that uses this entity type
            var entitySetTop = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace).SelectMany(s => s.EntitySets);
            //.Single()
            //.BaseEntitySets;
            var entitySet = entitySetTop
                .SingleOrDefault(s => s.ElementType.Name == entityType.Name);
            EntitySet entitySet2 = null;
            foreach (var s in entitySetTop) {
                if (s.ElementType.Name == entityType.Name) {
                    entitySet2 = s;
                    break;
                }
                var temp = entityType.BaseType;
                while (temp != null) {
                    if (s.ElementType.Name == temp.Name) {
                        entitySet2 = s;
                        break;
                    }
                    temp = temp.BaseType;
                }
                if (entitySet2 != null)
                    break;
            }
            entitySet = entitySet2;
            // Find the mapping between conceptual and storage model for this entity set
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);
            // Find the storage entity sets (tables) that the entity is mapped
            var tables = mapping
                .EntityTypeMappings.Where(f => {
                    if (f.IsHierarchyMapping) {
                        return f.EntityTypes.Any(e => e.Name == entityType.Name);
                    }
                    return f.EntityType.Name == entityType.Name;
                }).SelectMany(t => t.Fragments); //.Single()
            //.Fragments;
            // Return the table name from the storage entity set
            return tables.Select(f => (string)f.StoreEntitySet.MetadataProperties["Table"].Value ?? f.StoreEntitySet.Name);
        }
    }
