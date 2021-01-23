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
            EdmMember edmMember = baseEntity.ElementType.Members.Single(x => x.Name == propertyId);
            // The PropertyInfo connected to the EdmMember
            PropertyInfo property = (PropertyInfo)edmMember.MetadataProperties.Single(x => x.Name == "ClrPropertyInfo").Value;
            // Building the Expression
            ParameterExpression par = Expression.Parameter(typeof(TEntity));
            MemberExpression prop = Expression.Property(par, property);
            // cast to (int?)property
            // Note the use of int?, because the table could be empty!
            UnaryExpression conv = Expression.Convert(prop, typeof(int?));
            // An expression like x => x.Entity_Id
            LambdaExpression lambda = Expression.Lambda(conv, par);
            // Looking for the Queryable.Max<,>
            // The Queryable.Max<TSource, TResult> method
            // Looking for the Queryable.Max<,>
            // The Queryable.Max<TSource, TResult> method
            MethodInfo maxMethod = (from x in typeof(Queryable).GetMethods()
                                    where x.Name == "Max" && x.IsStatic
                                    let parameters = x.GetParameters()
                                    where parameters.Length == 2 
                                    let genericArguments = x.GetGenericArguments()
                                    where genericArguments.Length == 2 &&
                                        parameters[0].ParameterType == typeof(IQueryable<>).MakeGenericType(genericArguments[0]) &&
                                        parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(genericArguments))
                                    select x).Single();
            // The maxMethod changed to Queryable.Max<TEntity, int?>
            // Note the use of int?, because the table could be empty!
            MethodInfo maxMethod2 = maxMethod.MakeGenericMethod(typeof(TEntity), typeof(int?));
            // Remember that Queryable.Max<,> is static! so null as the first
            // parameter of Invoke()
            int? currentMaxID = (int?)maxMethod2.Invoke(null, new object[] { query, lambda });
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
