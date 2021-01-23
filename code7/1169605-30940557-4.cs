    public static int GetMaxId<TEntity>()
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
            var baseEntity = container.BaseEntitySets.Single(s => s.ElementType.Name == key);
            // 3. finally, we can create a basic query for this set
            var query = objectContext.CreateQuery<TEntity>("[" + baseEntity.Name + "]");
            // Looking for the property
            string propertyId = baseEntity.Name + "_" + "Id";
            // The PropertyInfo connected to the EdmMember
            PropertyInfo property = (PropertyInfo)typeof(TEntity).GetProperty(propertyId);
            // Building the Expression
            ParameterExpression par = Expression.Parameter(typeof(TEntity));
            MemberExpression prop = Expression.Property(par, property);
            // cast to (int?)property
            // Note the use of int?, because the table could be empty!
            UnaryExpression conv = Expression.Convert(prop, typeof(int?));
            // An expression like x => x.Entity_Id
            Expression<Func<TEntity, int?>> lambda = Expression.Lambda<Func<TEntity, int?>>(conv, par);
            int? currentMaxID = ((IQueryable<TEntity>)query).Max(lambda);
            // We change null to 0
            return currentMaxID ?? 0;
        }
        catch (Exception ex)
        {
            string exMessage = "GetMaxId.Exception";
            EntityModelDataProviderLogger.Fatal(exMessage, ex);
            throw;
        }
    }
