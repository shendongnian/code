    public static void GetEntitiesGeneric<TEntity>()// where TEntity : System.Data.Entity.Core.Objects.DataClasses.EntityObject  <-- NO LONGER NEEDED
    {
        try
        {
            var key = typeof(TEntity).Name;
            var adapter = (IObjectContextAdapter)MyDbContext;
            var objectContext = adapter.ObjectContext;
            // 1. we need the container for the conceptual model
            var container = objectContext.MetadataWorkspace.GetEntityContainer(
                objectContext.DefaultContainerName, System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace);
            // 2. we need the name given to the element set in that conceptual model
            var name = container.BaseEntitySets.Where((s) => s.ElementType.Name.Equals(key)).FirstOrDefault().Name;
            // 3. finally, we can create a basic query for this set
            var query = objectContext.CreateQuery<TEntity>("[" + name + "]");
            // Work with your query ...
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid Entity Type supplied for Lookup", ex);
        }
    }
