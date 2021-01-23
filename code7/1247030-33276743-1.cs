    static class MyContextExtensions
    {
        public static bool Exists<T>(this DbContext context, T entity)
            where T : class
        {
            // we need underlying object context to access EF model metadata
            var objContext = ((IObjectContextAdapter)context).ObjectContext;
            // this is the model metadata container
            var workspace = objContext.MetadataWorkspace;
            // this is metadata of particular CLR entity type
            var edmType = workspace.GetType(typeof(T).Name, typeof(T).Namespace, DataSpace.OSpace);
            // this is primary key metadata;
            // we need them to get primary key properties
            var primaryKey = (ReadOnlyMetadataCollection<EdmMember>)edmType.MetadataProperties.Single(_ => _.Name == "KeyMembers").Value;
            // let's build expression, that checks primary key value;
            // this is _CLR_ metatadata of primary key (don't confuse with EF metadata)
            var primaryKeyProperty = typeof(T).GetProperty(primaryKey[0].Name);
            // then, we need to get primary key value for passed entity
            var primaryKeyValue = primaryKeyProperty.GetValue(entity);
            // the expression:
            var parameter = Expression.Parameter(typeof(T));
            var expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.MakeMemberAccess(parameter, primaryKeyProperty), Expression.Constant(primaryKeyValue)), parameter);
            return context.Set<T>().Any(expression);
        }
    }
