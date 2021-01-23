    public static IQueryable<TEntity> GetQuery<TEntity>(this DbContext db, bool includeReferences = false) where TEntity : class
        {
            try
            {
                if (db == null)
                {
                    return null;
                }
                var key = typeof(TEntity).Name;
                var metaWorkspace = db.ToObjectContext().MetadataWorkspace;
                var workspaceItems = metaWorkspace.GetItems<EntityType>(DataSpace.OSpace);
                var workspaceItem = workspaceItems.First(f => f.FullName.Contains(key));
                var navProperties = workspaceItem.NavigationProperties;
                return !includeReferences
                        ? db.Set<TEntity>()
                        : navProperties.Aggregate((IQueryable<TEntity>)db.Set<TEntity>(), (current, navProperty) => current.Include(navProperty.Name));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid Entity Type supplied for Lookup", ex);
            }
        }
